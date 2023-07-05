﻿using Aplicacion.Constantes;
using Dominio.Entidades;
using IServicio.Configuracion;
using IServicios.Comprobante.DTOs;
using IServicios.Contador;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Transactions;

namespace Servicios.Comprobante
{
    public class Factura : Comprobante
    {
        private readonly IContadorServicio _contadorServicio;
        private readonly IConfiguracionServicio _configuracionServicio;

        public Factura()
        : base()
        {
            _contadorServicio = ObjectFactory.GetInstance<IContadorServicio>();
            _configuracionServicio = ObjectFactory.GetInstance<IConfiguracionServicio>();
        }




        public override long Insertar(ComprobanteDto comprobante)
        {
            using (var tran = new TransactionScope())
            {
                try
                {
                    int numeroComprobante = 0; 

                    var config = _configuracionServicio.Obtener();
                    if (config == null)
                        throw new Exception("Ocurrio un erorr al obtener la Configuración");
                        var cajaActual = _unidadDeTrabajo.CajaRepositorio.Obtener
                        (x =>
                        x.UsuarioAperturaId == comprobante.UsuarioId
                        && x.UsuarioCierreId == null).FirstOrDefault();

                    if (cajaActual == null)
                        throw new Exception("Ocurrio un error al obtener la Caja");
                        cajaActual.DetalleCajas = new List<DetalleCaja>();
                        
                    var facturaDto = (FacturaDto)comprobante;
                    Dominio.Entidades.Factura _facturaNueva = new Dominio.Entidades.Factura();

                    if (facturaDto.Estado == Estado.Pendiente && !facturaDto.VieneVentas)
                    {
                        _facturaNueva = _unidadDeTrabajo.FacturaRepositorio.Obtener(facturaDto.Id,
                            "DetalleComprobantes, Movimientos, FormaPagos");

                        if (_facturaNueva == null) throw new Exception("Ocurrio un rror al Obtener la Factura");

                        numeroComprobante = _facturaNueva.Numero;

                        // _facturaNueva.DetalleComprobantes = new List<DetalleComprobante>();
                        // _facturaNueva.Movimientos = new List<Movimiento>();
                        // _facturaNueva.FormaPagos = new List<FormaPago>();

                        facturaDto.Estado = Estado.Pagada;
                    }
                    else
                    {

                       numeroComprobante = _contadorServicio.ObtenerSiguienteNumeroComprobante(comprobante.TipoComprobante);

                        _facturaNueva = new Dominio.Entidades.Factura
                        {
                            ClienteId = facturaDto.ClienteId,
                            Descuento = facturaDto.Descuento,
                            EmpleadoId = facturaDto.EmpleadoId,
                            Estado = facturaDto.Estado,
                            Fecha = facturaDto.Fecha,
                            Iva105 = facturaDto.Iva105,
                            Iva21 = facturaDto.Iva21,
                            Numero = numeroComprobante,
                            SubTotal = facturaDto.SubTotal,
                            Total = facturaDto.Total,
                            PuestoTrabajoId = facturaDto.PuestoTrabajoId,
                            TipoComprobante = facturaDto.TipoComprobante,
                            UsuarioId = facturaDto.UsuarioId,
                            DetalleComprobantes = new List<DetalleComprobante>(),
                            Movimientos = new List<Movimiento>(),
                            FormaPagos = new List<FormaPago>(),
                            EstaEliminado = false
                        };
                        foreach (var item in facturaDto.Items)
                        {
                            if (config.FacturaDescuentaStock)
                            {
                                var stockActual =
                                _unidadDeTrabajo.StockRepositorio.Obtener(x =>
                                x.ArticuloId == item.ArticuloId
                                && x.DepositoId ==
                                config.DepositoVentaId).FirstOrDefault();
                                if (stockActual == null)
                                    throw new Exception("Ocurrio un error al obtener el Stock del Articulo");
                            if (stockActual.Cantidad >= item.Cantidad)
                                {
                                    stockActual.Cantidad -= item.Cantidad;
                                }
                                _unidadDeTrabajo.StockRepositorio.Modificar
                                (stockActual);
                            }
                            _facturaNueva.DetalleComprobantes.Add(new DetalleComprobante
                            {
                                Cantidad = item.Cantidad,
                                ArticuloId = item.ArticuloId,
                                Iva = item.Iva,
                                Descripcion = item.Descripcion,
                                Precio = item.Precio,
                                Codigo = item.Codigo,
                                SubTotal = item.SubTotal
                            });
                        }
                    }
                    if (facturaDto.Estado == Estado.Pagada)
                    {
                        _facturaNueva.Movimientos.Add(new Movimiento
                        {
                            ComprobanteId = _facturaNueva.Id,
                            CajaId = cajaActual.Id,
                            Fecha = facturaDto.Fecha,
                            Monto = facturaDto.Total,
                            UsuarioId = facturaDto.UsuarioId,
                            TipoMovimiento = TipoMovimiento.Ingreso,
                            Descripcion = $"Fa- { facturaDto.TipoComprobante.ToString() }-Nro { numeroComprobante }",
                            EstaEliminado = false
                        });
                        foreach (var fp in facturaDto.FormasDePagos)
                        {
                            switch (fp.TipoPago)
                            {
                                case TipoPago.Efectivo:
                                    _facturaNueva.FormaPagos.Add(new FormaPago
                                    {
                                        ComprobanteId = _facturaNueva.Id,
                                        Monto = fp.Monto,
                                        TipoPago = fp.TipoPago,
                                        EstaEliminado = false
                                    });
                                    cajaActual.TotalEntradaEfectivo += fp.Monto;
                                    cajaActual.DetalleCajas.Add(new DetalleCaja
                                    {
                                        Monto = fp.Monto,
                                        TipoPago = TipoPago.Efectivo
                                    });
                                    break;
                                case TipoPago.Tarjeta:
                                    var fpTarjeta = (FormaPagoTarjetaDto)fp;
                                    _facturaNueva.FormaPagos.Add(new FormaPagoTarjeta
                                    {
                                        ComprobanteId = _facturaNueva.Id,
                                        Monto = fpTarjeta.Monto,
                                        TipoPago = fpTarjeta.TipoPago,
                                        CantidadCuotas = fpTarjeta.CantidadCuotas,
                                        CuponPago = fpTarjeta.CuponPago,
                                        NumeroTarjeta = fpTarjeta.NumeroTarjeta,
                                        TarjetaId = fpTarjeta.TarjetaId,
                                        EstaEliminado = false
                                    });
                                    cajaActual.TotalEntradaTarjeta += fpTarjeta.Monto;
                                    cajaActual.DetalleCajas.Add(new DetalleCaja
                                    {
                                        Monto = fpTarjeta.Monto,
                                        TipoPago = TipoPago.Tarjeta
                                    });
                                    break;
                                case TipoPago.Cheque:

                                    var fpCheque = (FormaPagoChequeDto)fp;
                                    _facturaNueva.FormaPagos.Add(new FormaPagoCheque
                                    {
                                        ComprobanteId = _facturaNueva.Id,
                                        Cheque = new Cheque
                                        {
                                            BancoId = fpCheque.BancoId,
                                            ClienteId = fpCheque.ClienteId,
                                            FechaVencimiento =
                                            fpCheque.FechaVencimiento,
                                            Numero = fpCheque.Numero,
                                            EstaRechazado = false,
                                            EstaEliminado = false
                                        },
                                        Monto = fpCheque.Monto,
                                        TipoPago = TipoPago.Cheque
                                    });
                                    cajaActual.TotalEntradaCheque += fpCheque.Monto;
                                    cajaActual.DetalleCajas.Add(new DetalleCaja
                                    {
                                        Monto = fpCheque.Monto,
                                        TipoPago = TipoPago.Cheque
                                    });
                                    break;
                                case TipoPago.CtaCte:
                                    var fpCtaCTe = (FormaPagoCtaCteDto)fp;
                                    _facturaNueva.FormaPagos.Add(new FormaPagoCtaCte
                                    {
                                        Monto = fpCtaCTe.Monto,
                                        TipoPago = TipoPago.CtaCte,
                                        ClienteId = fpCtaCTe.ClienteId,
                                        EstaEliminado = false
                                    });
                                    _facturaNueva.Movimientos.Add(new MovimientoCuentaCorriente
                                    {
                                        ComprobanteId = _facturaNueva.Id,
                                        CajaId = cajaActual.Id,
                                        Fecha = facturaDto.Fecha,
                                        Monto = fpCtaCTe.Monto,
                                        UsuarioId = facturaDto.UsuarioId,
                                        TipoMovimiento =
                                        TipoMovimiento.Egreso,
                                        Descripcion = $"Fa- { facturaDto.TipoComprobante.ToString() }-Nro { numeroComprobante }",
                                        ClienteId = fpCtaCTe.ClienteId,
                                        EstaEliminado = false
                                    });
                                    cajaActual.TotalEntradaCtaCte +=
                                    fpCtaCTe.Monto;
                                    cajaActual.DetalleCajas.Add(new DetalleCaja
                                    {
                                        Monto = fpCtaCTe.Monto,
                                        TipoPago = TipoPago.CtaCte
                                    });
                                    break;
                            }
                        }
                        _unidadDeTrabajo.CajaRepositorio.Modificar(cajaActual);
                    }
                    if (facturaDto.VieneVentas)
                    {
                        _unidadDeTrabajo.FacturaRepositorio.Insertar(_facturaNueva);
                    }
                    else
                    {
                        _unidadDeTrabajo.FacturaRepositorio.Modificar(_facturaNueva);
                    }

                    _unidadDeTrabajo.Commit();
                    tran.Complete();
                    //Devolver ID para poder mostrar la factura (!)

                    return _facturaNueva.Id;
                }
                catch (DbEntityValidationException ex)
                {
                    var error = ex.EntityValidationErrors.SelectMany(v => v.ValidationErrors)
                        .Aggregate(string.Empty,
                            (current, validationError) =>
                                current +
                                ($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}. {Environment.NewLine}"
                                ));

                    tran.Dispose();
                    throw new Exception($"Ocurrió un error grave al grabar la factura. Error: {error}");
                }
              
            }
        }
    }
}
