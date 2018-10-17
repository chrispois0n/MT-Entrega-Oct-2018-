using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using miLibreria;
using System.Data; 


namespace MT_V1._1
{
    public partial class LogIn : Form
    {
        public static string Ustr = " ";
        public static bool permisos = false;
        public static string codigo = " ";
        //esta variable nos sirve para almacenar el usuario que se loggeo
        public LogIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtP.Text == "" || txtU.Text == "")
            {
                MessageBox.Show("Ingrese su usuario y contraseña");
            }
            else
            {

                try
                {
                    string CMD = string.Format("select * from usuarios where account = '" + txtU.Text + "' and psw = '" + txtP.Text + "' ");
                    //EL .TRIM() SIRVE PARA EVITAR ESPACIOS

                    DataSet ds = Utilidades.Ejecutar(CMD);

                    codigo = ds.Tables[0].Rows[0]["id_usuario"].ToString().Trim();

                    string cuenta = ds.Tables[0].Rows[0]["account"].ToString().Trim();
                    string password = ds.Tables[0].Rows[0]["psw"].ToString().Trim();

                    if (cuenta == txtU.Text.Trim() && password == txtP.Text.Trim())
                    {
                        if (Convert.ToBoolean(ds.Tables[0].Rows[0]["status_admin"]) == true)
                        {
                            permisos = true;
                        }
                        else
                        {
                            permisos = false;
                        }
                        //esta condicional la usare mas tarde para brindar accesos al usuario ingresado


                        //MessageBox.Show("Sesion iniciada");
                        DineroCaja abrir = new DineroCaja();
                        abrir.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrecta");
                    }

                    //esto lo hace una matriz
                }
                catch (Exception error)
                {
                   // MessageBox.Show("" + error.Message);
                    MessageBox.Show("Usuario o contraseña incorrecta");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }

        private void txtP_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtU_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
