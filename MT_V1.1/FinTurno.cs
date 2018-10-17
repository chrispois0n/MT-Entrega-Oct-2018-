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
    public partial class FinTurno : Form
    {
        public FinTurno()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtDFT.Text == "")
            {
                MessageBox.Show("Ingrese una cantidad antes de salir!");
            }
            else
            {
                //El siguiente segmento de codigo hace el insert a la base de datos de sesiones

                string FHC = DateTime.Now.ToString(@"dd\/MM\/yyyy h\:mm:ss tt");
                Decimal DFT = Convert.ToDecimal(txtDFT.Text);

                try
                {
                    string cmd = String.Format("EXEC RegistroSesiones2 '{0}','{1}','{2}','{3}','{4}'", DineroCaja.FHII, FHC, DineroCaja.DI, DFT, DineroCaja.id);
                    Utilidades.Ejecutar(cmd);
                    //MessageBox.Show("Registro realizado");
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }

                ////
                this.Close();
                Application.Exit();
                //esto cierra definitivamente toda la aplicacion
            }
        }

        private void FinTurno_Load(object sender, EventArgs e)
        {
            string cmd = "select * from usuarios where id_usuario =" + LogIn.codigo;

            DataSet ds = Utilidades.Ejecutar(cmd);

            lblU.Text = ds.Tables[0].Rows[0]["account"].ToString().Trim();
        }

        private void txtDFT_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDFT_TextChanged(object sender, EventArgs e)
        {
            if (txtDFT.Text == "")
            {
                txtDFT.Text = "";
            }
            else
            {

            }
        }
    }
}
