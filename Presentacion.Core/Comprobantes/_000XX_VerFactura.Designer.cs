
namespace Presentacion.Core.Comprobantes
{
    partial class _000XX_VerFactura
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.obtenerInfoFacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comercioDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comercioDataSet1 = new Presentacion.Core.comercioDataSet();
            this.obtenerDetalleFacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.obtenerPersonaClienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.obtenerConfigBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.obtenerInfoFacturaTableAdapter1 = new Presentacion.Core.comercioDataSetTableAdapters.ObtenerInfoFacturaTableAdapter();
            this.obtenerDetalleFacturaTableAdapter = new Presentacion.Core.comercioDataSetTableAdapters.ObtenerDetalleFacturaTableAdapter();
            this.obtenerPersonaClienteTableAdapter1 = new Presentacion.Core.comercioDataSetTableAdapters.ObtenerPersonaClienteTableAdapter();
            this.tableAdapterManager1 = new Presentacion.Core.comercioDataSetTableAdapters.TableAdapterManager();
            this.obtenerConfigTableAdapter1 = new Presentacion.Core.comercioDataSetTableAdapters.ObtenerConfigTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.obtenerInfoFacturaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comercioDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comercioDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obtenerDetalleFacturaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obtenerPersonaClienteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obtenerConfigBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // obtenerInfoFacturaBindingSource
            // 
            this.obtenerInfoFacturaBindingSource.DataMember = "ObtenerInfoFactura";
            this.obtenerInfoFacturaBindingSource.DataSource = this.comercioDataSet1BindingSource;
            // 
            // comercioDataSet1BindingSource
            // 
            this.comercioDataSet1BindingSource.DataSource = this.comercioDataSet1;
            this.comercioDataSet1BindingSource.Position = 0;
            // 
            // comercioDataSet1
            // 
            this.comercioDataSet1.DataSetName = "comercioDataSet";
            this.comercioDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // obtenerDetalleFacturaBindingSource
            // 
            this.obtenerDetalleFacturaBindingSource.DataMember = "ObtenerDetalleFactura";
            this.obtenerDetalleFacturaBindingSource.DataSource = this.comercioDataSet1BindingSource;
            // 
            // obtenerPersonaClienteBindingSource
            // 
            this.obtenerPersonaClienteBindingSource.DataMember = "ObtenerPersonaCliente";
            this.obtenerPersonaClienteBindingSource.DataSource = this.comercioDataSet1;
            // 
            // obtenerConfigBindingSource
            // 
            this.obtenerConfigBindingSource.DataMember = "ObtenerConfig";
            this.obtenerConfigBindingSource.DataSource = this.comercioDataSet1BindingSource;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.obtenerInfoFacturaBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.obtenerDetalleFacturaBindingSource;
            reportDataSource3.Name = "DataSet3";
            reportDataSource3.Value = this.comercioDataSet1BindingSource;
            reportDataSource4.Name = "DataSet4";
            reportDataSource4.Value = this.obtenerPersonaClienteBindingSource;
            reportDataSource5.Name = "DataSet5";
            reportDataSource5.Value = this.obtenerConfigBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Presentacion.Core.FacturaVer.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // obtenerInfoFacturaTableAdapter1
            // 
            this.obtenerInfoFacturaTableAdapter1.ClearBeforeFill = true;
            // 
            // obtenerDetalleFacturaTableAdapter
            // 
            this.obtenerDetalleFacturaTableAdapter.ClearBeforeFill = true;
            // 
            // obtenerPersonaClienteTableAdapter1
            // 
            this.obtenerPersonaClienteTableAdapter1.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.UpdateOrder = Presentacion.Core.comercioDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // obtenerConfigTableAdapter1
            // 
            this.obtenerConfigTableAdapter1.ClearBeforeFill = true;
            // 
            // _000XX_VerFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "_000XX_VerFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imprimir factura";
            this.Load += new System.EventHandler(this._000XX_VerFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.obtenerInfoFacturaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comercioDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comercioDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obtenerDetalleFacturaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obtenerPersonaClienteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obtenerConfigBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private comercioDataSetTableAdapters.ObtenerInfoFacturaTableAdapter obtenerInfoFacturaTableAdapter1;
        private comercioDataSet comercioDataSet1;
        private System.Windows.Forms.BindingSource comercioDataSet1BindingSource;
        private System.Windows.Forms.BindingSource obtenerInfoFacturaBindingSource;
        private System.Windows.Forms.BindingSource obtenerDetalleFacturaBindingSource;
        private comercioDataSetTableAdapters.ObtenerDetalleFacturaTableAdapter obtenerDetalleFacturaTableAdapter;
        private comercioDataSetTableAdapters.ObtenerPersonaClienteTableAdapter obtenerPersonaClienteTableAdapter1;
        private System.Windows.Forms.BindingSource obtenerPersonaClienteBindingSource;
        private comercioDataSetTableAdapters.TableAdapterManager tableAdapterManager1;
        private comercioDataSetTableAdapters.ObtenerConfigTableAdapter obtenerConfigTableAdapter1;
        private System.Windows.Forms.BindingSource obtenerConfigBindingSource;
    }
}