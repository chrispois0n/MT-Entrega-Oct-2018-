using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miLibreria
{
    public partial class errorTxtBox : TextBox
    {
        public errorTxtBox()
        {
            InitializeComponent();
        }

        public bool Validar
        {
            set;
            get;
        }
    }
}
