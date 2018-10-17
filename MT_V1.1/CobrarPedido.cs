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
    public partial class CobrarPedido : Form
    {
        public decimal TotalPedido,RestantePedido,AnticipoPedido;
        public int ArticuloPedido;
        public CobrarPedido()
        {
            InitializeComponent();
        }

        public CobrarPedido(decimal TP, int AP)
        {
            InitializeComponent();
            TotalPedido = TP;
            ArticuloPedido = AP;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CobrarPedido_Load(object sender, EventArgs e)
        {
            PV pv = new _1.PV();
            decimal tP = Convert.ToDecimal(pv.TotalPedido.ToString());
            int aP = Convert.ToInt32(pv.artPedido.ToString());

            lblTotal.Text = "$ " + TotalPedido.ToString();
            lblRestante.Text = "$ " + TotalPedido.ToString();
            lblArt.Text = ArticuloPedido.ToString();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if(txtPago.Text != "")
            {
                decimal Pago = Convert.ToDecimal(txtPago.Text);
                decimal Cambio = Pago - AnticipoPedido;
                lblCambio.Text = Cambio.ToString();
            }
            else
            {

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == (int)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == (int)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == (int)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                AnticipoPedido = Convert.ToDecimal(textBox5.Text);
                RestantePedido = TotalPedido - AnticipoPedido;
                lblRestante.Text = "$ " + RestantePedido.ToString();
                lblTotalAnticipo.Text = "$ " + AnticipoPedido.ToString();
            }
            else
            {
                textBox5.Text = Convert.ToString(0);
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == (int)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
