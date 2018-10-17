using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MT_V1._1
{
    public partial class ReportePrueba : Form
    {
        public ReportePrueba()
        {
            InitializeComponent();
        }

        private void ReportePrueba_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DatasetPrueba.DatosFactura' Puede moverla o quitarla según sea necesario.
           // this.DatosFacturaTableAdapter.Fill(this.DatasetPrueba.DatosFactura);

            this.reportViewer1.RefreshReport();
        }
    }
}
