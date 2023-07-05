using System;
using System.Windows.Forms;
using Aplicacion.Constantes;
using IServicios.Caja;
using Presentacion.Core.Articulo;
using Presentacion.Core.Banco;
using Presentacion.Core.Caja;
using Presentacion.Core.Cliente;
using Presentacion.Core.Comprobantes;
using Presentacion.Core.CondicionIva;
using Presentacion.Core.Configuracion;
using Presentacion.Core.Departamento;
using Presentacion.Core.Empleado;
using Presentacion.Core.FormaPago;
using Presentacion.Core.Localidad;
using Presentacion.Core.Provincia;
using Presentacion.Core.Usuario;
using PresentacionBase.Formularios;
using StructureMap;

namespace CommerceApp
{
    public partial class Principal : Form
    {
        private readonly ICajaServicio _cajaServicio;

        public Principal(ICajaServicio cajaServicio)
        {
            InitializeComponent();
            nombreUsuario.Text = $"{Identidad.Nombre } {Identidad.Apellido}";
            perfil.Image = Imagen.ConvertirImagen(Identidad.Foto);
            CustomizeDesign();

            _cajaServicio = cajaServicio;

        }

        private void ActualizarInicio() 
        {
            bvnd.Visible = false;
            nombreUsuario.Visible = false;
            perfil.Visible = false;

        }

        private void CustomizeDesign()
        {
            panelClientes.Visible = false;
            panelConceptos.Visible = false;
            panelConfiguracion.Visible = false;
            panelCaja.Visible = false;
        }

        private void HideSubMenu()
        {
            if (panelClientes.Visible == true)
                panelClientes.Visible = false;
            if (panelConceptos.Visible == true)
                panelConceptos.Visible = false;
            if (panelConfiguracion.Visible == true)
                panelConfiguracion.Visible = false;
            if (panelCaja.Visible == true)
                panelCaja.Visible = false;
        }

        private void ShowSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                HideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //Hover de botones
        private void botonVentas_MouseEnter(object sender, EventArgs e)
        {
            botonVentas.ForeColor = System.Drawing.Color.Gray;

        }

        private void botonCerrarSesion_Click(object sender, EventArgs e)
        {
            Identidad.Limpiar();
            ActualizarInicio();
            Close();
            ObjectFactory.GetInstance<Login>().ShowDialog();
        }

        private void botonClientes_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelClientes);
        }

        private void botonConceptos_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelConceptos);
        }

        private void botonConfiguracion_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelConfiguracion);
        }

        private void botonVentas_Click(object sender, EventArgs e)
        {
            if (Identidad.EmpleadoId == 0 || Identidad.UsuarioId == 0)
            {
                MessageBox.Show("Acceso denegado");
                return;
            }

            if (_cajaServicio.VerificarSiExisteCajaAbierta(Identidad.UsuarioId))
            {
                ObjectFactory.GetInstance<_00050_Venta>().Show();
            }
            else
            {
                if (MessageBox.Show("La caja aún no fue abierta. Desea abrir una?", "Atencion",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    var fCaja = ObjectFactory.GetInstance<_00039_AperturaCaja>();
                    fCaja.ShowDialog();
                    if (fCaja.CajaAbierta)
                    {
                        ObjectFactory.GetInstance<_00050_Venta>().Show();
                    }
                }
            }
        }

        private void botonCaja_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelCaja);
        }

        private void botonArticulos_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00017_Articulo>().ShowDialog();
        }

        private void consultaClienteBtn_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00009_Cliente>().ShowDialog();
        }

        private void pagoCtaCteBtn_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00034_ClienteCtaCte>().ShowDialog();
        }

        private void provinciaBtn_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00001_Provincia>().ShowDialog();
        }

        private void departamentoBtn_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00003_Departamento>().ShowDialog();
        }

        private void localidadBtn_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00005_Localidad>().ShowDialog();
        }

        private void rubroBtn_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00019_Rubro>().ShowDialog();
        }

        private void marcaBtn_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00021_Marca>().ShowDialog();
        }

        private void unidadMedidaBtn_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00023_UnidadDeMedida>().ShowDialog();
        }

        private void ivaBtn_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00013_CondicionIva>().ShowDialog();
        }

        private void listasDePrecioBtn_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00032_ListaPrecio>().ShowDialog();
        }

        private void depositoBtn_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00054_Deposito>().ShowDialog();
        }

        private void configuracionBtn_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00012_Configuracion>().ShowDialog();
        }

        private void empleadosBtn_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00007_Empleado>().ShowDialog();
        }

        private void usuariosBtn_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00011_Usuario>().ShowDialog();
        }

        private void consultaCajaBtn_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00038_Caja>().ShowDialog();
        }

        private void pendientesCajaBtn_Click(object sender, EventArgs e)
        {
            ObjectFactory.GetInstance<_00049_CobroDiferido>().ShowDialog();
        }
    }
   
}
