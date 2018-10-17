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
    public partial class Cobrar : Form
    {
        public decimal totalllevar, totalpedido, TotalMA, TotalMB, TotalMC;
        public int articulos, aA, aB,aC, Index, modo;

        private void txtPago_KeyPress(object sender, KeyPressEventArgs e)
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

        public Cobrar()
        {
            InitializeComponent();
        }

        public Cobrar(decimal tl, int A1, int Modo)
        {
            InitializeComponent();
            totalllevar = tl;
            articulos = A1;
            modo = Modo;

        }
        public Cobrar(decimal MA, decimal MB, decimal MC, int AA, int AB, int AC, int INDEX,int Modo)
        {
            InitializeComponent();
            TotalMA = MA;
            TotalMB = MB;
            TotalMC = MC;
            aA = AA;
            aB = AB;
            aC = AC;
            Index = INDEX;
            modo = Modo;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (modo == 0)
            {
                if (txtPago.Text != "")
                {
                    decimal pago = Convert.ToDecimal(txtPago.Text);
                    decimal cambio = pago - totalllevar;
                    lblCambio.Text = "$ " + cambio.ToString();
                }
                else
                {
                    txtPago.Text = "0";
                }
            } else if (modo == 1)
            {
                if(Index == 0)
                {
                    if (txtPago.Text != "")
                    {
                        decimal pago = Convert.ToDecimal(txtPago.Text);
                        decimal cambio = pago - TotalMA;
                        lblCambio.Text = "$ " + cambio.ToString();
                    }
                    else
                    {
                        MessageBox.Show("");
                    }
                }
                else if (Index == 1)
                {
                    if (txtPago.Text != "")
                    {
                        decimal pago = Convert.ToDecimal(txtPago.Text);
                        decimal cambio = pago - TotalMB;
                        lblCambio.Text = "$ " + cambio.ToString();
                    }
                    else
                    {
                        MessageBox.Show("");
                    }
                }
                else if (Index == 2)
                {
                    if (txtPago.Text != "")
                    {
                        decimal pago = Convert.ToDecimal(txtPago.Text);
                        decimal cambio = pago - TotalMC;
                        lblCambio.Text = "$ " + cambio.ToString();
                    }
                    else
                    {
                        MessageBox.Show("");
                    }
                }
            }
        }

        private void Cobrar_Load(object sender, EventArgs e)
        {
            PV pv = new PV();
            if (modo == 0)
            {
                decimal TLlevar = Convert.ToDecimal(pv.totalLlevar.ToString());
                int Articuloss = Convert.ToInt32(pv.artLlevar.ToString());

                lblTT.Text = "$ " + totalllevar.ToString();
                lblArticulos.Text = articulos.ToString();
            } else if (modo == 1)
            {
                if(Index == 0)
                {
                    lblTT.Text ="$ " + TotalMA.ToString();
                    lblArticulos.Text = aA.ToString();
                } else if (Index == 1)
                {
                    lblTT.Text ="$ " + TotalMB.ToString();
                    lblArticulos.Text = aB.ToString();
                }
                else if (Index == 2)
                {
                    lblTT.Text ="$ "  + TotalMC.ToString();
                    lblArticulos.Text = aC.ToString();
                }
            }
            //lblTT.Text =Convert.ToString( pv.total());
            
        }
    }
}
