using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.Comprobantes
{
    public partial class _000XX_VerFactura : Form
    {
        public _000XX_VerFactura(long facturaId, long clienteId)
        {
            InitializeComponent();
            this.obtenerInfoFacturaTableAdapter1.Fill(comercioDataSet1.ObtenerInfoFactura, facturaId);
            this.obtenerDetalleFacturaTableAdapter.Fill(comercioDataSet1.ObtenerDetalleFactura, facturaId);
            this.obtenerPersonaClienteTableAdapter1.Fill(comercioDataSet1.ObtenerPersonaCliente, clienteId);
            this.obtenerConfigTableAdapter1.Fill(comercioDataSet1.ObtenerConfig);
            this.reportViewer1.RefreshReport();
        }

        private void _000XX_VerFactura_Load(object sender, EventArgs e)
        {
        }
    }
}
