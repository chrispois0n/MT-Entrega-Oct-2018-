using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using miLibreria;

namespace MT_V1._1
{
    public partial class DineroCaja : Form
    {
        public static decimal DI;
        public static int id;
        public static string FHII;
        public DineroCaja()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtDI.Text == "")
            {
                MessageBox.Show("Ingrese una cantidad antes de continuar!");
            }
            else
            {
                DI = Convert.ToDecimal(txtDI.Text);
                id = Convert.ToInt32(lblId.Text);

                PV abrir = new _1.PV();
                abrir.Show();
                //PROBABLEMENTE UN DELAY
                this.Hide();
                //COMO CERRARLO 
            }
        }

        private void DineroCaja_Load(object sender, EventArgs e)
        {
            string cmd = "select * from usuarios where id_usuario =" + LogIn.codigo;

            DataSet ds = Utilidades.Ejecutar(cmd);

            lblAccount.Text = ds.Tables[0].Rows[0]["account"].ToString().Trim();
            lblNombre.Text = ds.Tables[0].Rows[0]["nombre"].ToString().Trim();
            lblId.Text = ds.Tables[0].Rows[0]["id_usuario"].ToString().Trim();

            string FHI = DateTime.Now.ToString(@"dd\/MM\/yyyy h\:mm:ss tt");
            FHII = FHI;
            lblInicioTurno.Text = FHI;
        }

        private void txtDI_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDI_TextChanged(object sender, EventArgs e)
        {
            if(txtDI.Text == "")
            {
                txtDI.Text = "";
            }
            else
            {

            }
        }
    }
}
