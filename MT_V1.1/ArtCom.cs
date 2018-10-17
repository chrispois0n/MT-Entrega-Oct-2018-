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
    public partial class ArtCom : Form
    {
        public string descripcionAC;
        public int cantidadAC;
        public decimal precioAC;
        public ArtCom()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Agregar 

            string descripcion = Convert.ToString(txtDescripcion.Text);
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            decimal precio = Convert.ToDecimal(txtPrecio.Text);
            decimal importe = cantidad * precio;
            PV pv = new PV(descripcion, cantidad ,precio, importe );
;

            pv.DGV_V_L.Rows.Add(0000, descripcion, 0, cantidad, precio, importe);
            MessageBox.Show(descripcion + cantidad + precio);
            this.Close();
            
        }
    }
}
