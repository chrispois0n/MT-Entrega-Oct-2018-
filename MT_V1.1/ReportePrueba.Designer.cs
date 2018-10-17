namespace MT_V1._1
{
    partial class ReportePrueba
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportePrueba));
            this.DatosFacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DatasetPrueba = new MT_V1._1.DatasetPrueba();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DatosFacturaTableAdapter = new MT_V1._1.DatasetPruebaTableAdapters.DatosFacturaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DatosFacturaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DatasetPrueba)).BeginInit();
            this.SuspendLayout();
            // 
            // DatosFacturaBindingSource
            // 
            this.DatosFacturaBindingSource.DataMember = "DatosFactura";
            this.DatosFacturaBindingSource.DataSource = this.DatasetPrueba;
            // 
            // DatasetPrueba
            // 
            this.DatasetPrueba.DataSetName = "DatasetPrueba";
            this.DatasetPrueba.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetPrueba";
            reportDataSource1.Value = this.DatosFacturaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MT_V1._1.InformePrueba.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(884, 749);
            this.reportViewer1.TabIndex = 0;
            // 
            // DatosFacturaTableAdapter
            // 
            this.DatosFacturaTableAdapter.ClearBeforeFill = true;
            // 
            // ReportePrueba
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 749);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportePrueba";
            this.Text = "ReportePrueba";
            this.Load += new System.EventHandler(this.ReportePrueba_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DatosFacturaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DatasetPrueba)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource DatosFacturaBindingSource;
        private DatasetPrueba DatasetPrueba;
        private DatasetPruebaTableAdapters.DatosFacturaTableAdapter DatosFacturaTableAdapter;
        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}