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
    public partial class Salir : Form
    {
        public Salir()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PV PV = new PV();
            PV.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FinTurno abrir = new FinTurno();
            abrir.Show();
            this.Hide();
        }
    }
}
