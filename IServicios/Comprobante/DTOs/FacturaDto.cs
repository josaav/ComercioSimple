using Aplicacion.Constantes;
using System;

namespace IServicios.Comprobante.DTOs
{
    public class FacturaDto : ComprobanteDto
    {
        public long ClienteId { get; set; }
        public long PuestoTrabajoId { get; set; }
        public Estado Estado { get; set; }

        public bool VieneVentas { get; set; }

        public static implicit operator FacturaDto(long v)
        {
            throw new NotImplementedException();
        }
    }


}
