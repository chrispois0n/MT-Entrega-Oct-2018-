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
using System.Data.SqlClient;


namespace MT_V1._1
{
    public partial class PV : Form
    {
        int bdU = 0; // Bandera para update 
        string busquedaUsuario = "";
        int tipoVenta = 1;
        decimal totalPLL = 0;
        public static int cont_fila = 0, contF_LL = 0, contF_MA = 0, contF_MB = 0, contF_MC = 0, contF_P = 0, MesaSeleccionada = 0;
        public decimal totalLlevar, TotalPedido, TotalMesaA, TotalMesaB, TotalMesaC, precioArtCom, importeArtCom, pago, cambio;
        public int artLlevar, artPedido, artMesaA, artMesaB, artMesaC, Modo, cantidadArtCom;
        public string descripcionArtCom;



        public PV()
        {
            InitializeComponent();
        }
        public PV(string descripcionAC, int cantidadAC, decimal precioAC, decimal importeAC)
        {
            InitializeComponent();
            descripcionArtCom = descripcionAC;
            cantidadArtCom = cantidadAC;
            precioArtCom = precioAC;
            importeArtCom = importeAC;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
//panel
        {
            panelReportes.Hide();
            panelInventarios.Hide();
            panelProductos.Hide();
            panelVentas.Show();
            panelPLL.Show();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tipoVenta = 1;
            panelReportes.Hide();
            panelPed.Hide();
            panelME.Hide();
            panelPLL.Show();

        }
        //panel

        private void button8_Click(object sender, EventArgs e)
        {
            tipoVenta = 2;
            panelReportes.Hide();
            panelPed.Hide();
            panelPLL.Hide();
            panelME.Show();
        }
        //panel

        private void button25_Click(object sender, EventArgs e)
            //Boton para cobrar pedidos
        {
            if (contF_P > 0)
            {

            desactivarProdutos();
            btnEliminarPediddo.Enabled = false;
     
     

            pnlCobrarPe.Show();
            btn_CobrarPedido.Enabled = false;

            }
            else
            {
                MessageBox.Show("No hay articulos por cobrar!");
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            Salir abrir = new _1.Salir();
            abrir.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            tipoVenta = 3;
            panelReportes.Hide();
            panelPed.Show();
            panelPLL.Hide();
            panelME.Hide();
          
        }
        //panel

        private void button29_Click(object sender, EventArgs e)
        {
            //Boton cobrar Mesas
            if (MesaSeleccionada == 0)
            {
                if (contF_MA > 0)
                {
                    int cant = Convert.ToInt32(artMesaA);
                    decimal total = Convert.ToDecimal(TotalMesaA);
                    pnlCobrarPlL.Show();
                    button29.Enabled = false;
                    desactivarProdutos();
                }
                else
                {
                    MessageBox.Show("No hay articulos por cobrar!");

                }
            }
            else if (MesaSeleccionada == 1)
            {
                if (contF_MB > 0)
                {
                    int cant = Convert.ToInt32(artMesaB);
                    decimal total = Convert.ToDecimal(TotalMesaB);
                    pnlCobrarPlL.Show();
                    button29.Enabled = false;
                    desactivarProdutos();
                }
                else
                {
                    MessageBox.Show("No hay articulos por cobrar!");

                }
            }
            else if (MesaSeleccionada == 2)
            {
                if (contF_MC > 0)
                {
                    int cant = Convert.ToInt32(artMesaB);
                    decimal total = Convert.ToDecimal(TotalMesaB);
                    pnlCobrarPlL.Show();
                    button29.Enabled = false;
                    desactivarProdutos();
                }
                else
                {
                    MessageBox.Show("No hay articulos por cobrar!");

                }
            }

           
            Modo = 1;

            
        }

        private void button24_Click(object sender, EventArgs e)
        {
            //Boton cobrar Para llevar
            if (contF_LL > 0)
            {

            Modo = 0;
            int cant = Convert.ToInt32(artLlevar);
            decimal total = Convert.ToDecimal(totalLlevar);
            

            pnlCobrarPlL.Show();
            button24.Enabled = false;
            desactivarProdutos();
            button23.Enabled = false;

            }
            else
            {
                MessageBox.Show("No hay articulos por Cobrar!");
            }


        }

        private void button21_Click(object sender, EventArgs e)
        {
            pnlArtCom.Show();
            //ArtCom abrir = new ArtCom();
            //abrir.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panelReportes.Hide();
            panelProductos.Hide();
            panelVentas.Hide();
            panelInventarios.Show();
            DGV_I_I.DataSource = llenadoDGV("productos").Tables[0];
        }
        //panel

        private void button2_Click(object sender, EventArgs e)
        {
            panelReportes.Hide();
            panelInventarios.Hide();
            panelVentas.Hide();
            panelProductos.Show();
        }
        //panel
        int usuario;
        private void PV_Load(object sender, EventArgs e)
        {
            panelReportes.Hide();
            panelInventarios.Hide();
            panelProductos.Hide();
            panelVentas.Show();


            string cmd = "select * from usuarios where id_usuario =" + LogIn.codigo;

            DataSet ds = Utilidades.Ejecutar(cmd);

            lblUturno.Text = ds.Tables[0].Rows[0]["account"].ToString().Trim();
            usuario = Convert.ToInt32(ds.Tables[0].Rows[0]["id_usuario"].ToString().Trim());


            panelVentas.Show();

            if (LogIn.permisos == true)
            {
                btnProductos.Enabled = true;
                btnInventarios.Enabled = true;
                btnReportes.Enabled = true;


            }else
            {
               
            }
        }



        private void button4_Click(object sender, EventArgs e)
        {
            panelUsuarios.Hide();
            panelReportes2.Hide();
            panelSesiones.Show();


            DGVSesiones.DataSource = llenadoDGV("sesiones").Tables[0];
            //Falta hacer las llaves foraneas para que se muestre el nombre del usuario

           
            
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            panelReportes.Show();
            panelProductos.Hide();
            panelVentas.Hide();
            panelInventarios.Hide();
            DGVSesiones.DataSource = llenadoDGV("sesiones").Tables[0];
            DGVUsuarios.DataSource = llenadoDGV("usuarios").Tables[0];



        }
        //panel



        private void btn_R_U_Click(object sender, EventArgs e)
        {
            panelUsuarios.Show();
            panelSesiones.Hide();
            panelReportes2.Hide();
            DGVUsuarios.DataSource = llenadoDGV("usuarios").Tables[0];
        }
        public DataSet llenadoDGV(string tabla)
        {
            DataSet ds;
            string cmd = string.Format("Select * from " + tabla);
            ds = Utilidades.Ejecutar(cmd);
            return ds;
        }

        private void btnP1_Click(object sender, EventArgs e)
        {
            int v = 1;
            bdU = 1;

            consultar(v);


            // falta hacer el update de informacion con el boton actualizar


        }

        public  void consultar (int v)
        {
            string cmd = string.Format("Select * from productos where id_producto  ='{0}'", v);

            DataSet ds = Utilidades.Ejecutar(cmd);

            txtP_IdP.Text = ds.Tables[0].Rows[0]["id_producto"].ToString().Trim();
            txtP_descripcion.Text = ds.Tables[0].Rows[0]["descripcion"].ToString().Trim();
            txtP_stock.Text = ds.Tables[0].Rows[0]["stock"].ToString().Trim();
            txtP_Precio.Text = ds.Tables[0].Rows[0]["precio"].ToString().Trim();
        }

        public void ActualizarProductos (int p)
        {
            try
            {
                string dP = txtP_descripcion.Text;
                int sP = Convert.ToInt32(txtP_stock.Text);
                decimal pP = Convert.ToDecimal(txtP_Precio.Text);

                string cmd = string.Format("update productos set descripcion = '{0}', stock = '{1}',precio='{2}' where id_producto = '{3}'", dP, sP, pP, bdU);

                DataSet ds = Utilidades.Ejecutar(cmd);

                
            } catch (Exception err)
            {
                MessageBox.Show(err.Message);
                MessageBox.Show("Llame al 6182003575 para recibir soporte");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //borrar omg
        
        }//nada


        private void button10_Click(object sender, EventArgs e)
        {//Y ESTO QUE?
            bool existe = false;
            int num_fila = 0;
            if (cont_fila == 0)
            {
                DGV_V_L.Rows.Add("Asado Rojo", 13, 2, 8.00);
                double importe = Convert.ToDouble(DGV_V_L.Rows[cont_fila].Cells[2].Value) * Convert.ToDouble(DGV_V_L.Rows[cont_fila].Cells[3].Value);
                DGV_V_L.Rows[cont_fila].Cells[4].Value = importe;

                cont_fila++;
            }
            else
            {
                foreach(DataGridViewRow fila  in DGV_V_L.Rows)
                {
                    if(fila.Cells[0].ToString()=="Asado Rojo")
                    {
                        existe = true;
                        num_fila = fila.Index;
                       
                    }
                }

            }
        }

        #region Como hacer una region
        #endregion

        #region Botones de ACTUALIZAR PRODUCTOS
        private void button44_Click(object sender, EventArgs e)
        {
            int v = 2;
            bdU = 2;

            consultar(v);
        }

        private void button43_Click(object sender, EventArgs e)
        {
            int v = 3;
            bdU = 3;
            consultar(v);
        }

        private void button35_Click(object sender, EventArgs e)
        {
            int v = 4;
            bdU = 4;
            consultar(v);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            int v = 5;
            bdU = 5;

            consultar(v);
        }

        private void button42_Click(object sender, EventArgs e)
        {
            int v = 6;
            bdU = 6;
            consultar(v);
        }

        private void button41_Click(object sender, EventArgs e)
        {
            int v = 7;
            bdU = 7;
            consultar(v);
        }

        private void button40_Click(object sender, EventArgs e)
        {
            int v = 8;
            bdU = 8;
            consultar(v);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            int v = 9;
            bdU = 9;
            consultar(v);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int v = 10;
            bdU = 10;
            consultar(v);
        }

        private void button39_Click(object sender, EventArgs e)
        {
            int v = 11;
            bdU = 11;
            consultar(v);
        }

        private void button38_Click(object sender, EventArgs e)
        {
            int v = 12;
            bdU = 12;
            consultar(v);
        }

        private void button37_Click(object sender, EventArgs e)
        {
            int v = 13;
            bdU = 13;
            consultar(v);
        }

        private void button36_Click(object sender, EventArgs e)
        {
            int v = 14;
            bdU = 14;
            consultar(v);
        }

        #endregion
        private void button46_Click(object sender, EventArgs e)
        {
            if (bdU == 0)
            {
                MessageBox.Show("Seleccione un producto");
            }
            else
            {
                consultar(bdU);
            }
        }

        private void button47_Click(object sender, EventArgs e)
        {
            if (bdU == 0)
            {
                MessageBox.Show("Seleccione un producto");
            }
            else
            {
                if (txtP_descripcion.Text == "" || txtP_stock.Text == "" || txtP_Precio.Text == "")
                {
                    MessageBox.Show("Ingrese: descripcion, stock y precio para continuar");
                }
                else
                {
                    ActualizarProductos(bdU);
                    MessageBox.Show("Producto actualizado");
                    txtP_descripcion.Text = "";
                    txtP_stock.Text = "";
                    txtP_Precio.Text = "";
                    txtP_IdP.Text = "";
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //borrar
        } // nada

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            //borrar
        } // nada

        private void button45_Click(object sender, EventArgs e)
        {
            //NuevoUsuario
            panelR_U_NU.Show();
            panelR_U_M.Hide();
        }

        private void btnModificarU_Click(object sender, EventArgs e)
        {
            panelR_U_NU.Hide();
            panelR_U_M.Show();
        }

        private void btnReportes2_Click(object sender, EventArgs e)
        {
            panelUsuarios.Hide();
            panelSesiones.Hide();
            panelReportes2.Show();

            DGV_R_R.DataSource = llenadoDGV("Ventas").Tables[0];
            DGV_Pedidos.DataSource = llenadoDGV("pedidos").Tables[0];


        }

        private void button49_Click(object sender, EventArgs e) //guardar nuevo usuarios
        {
           
            string nombre, usuario, psw1, psw2;
           
            int status =0;
            nombre = txtNombre.Text;
            usuario = txtUsuario.Text;
            psw1 = txtPsw1.Text;
            psw2 = txtpsw2.Text;

            try
            {
                if (psw1 == psw2)
                {
                    if (rBtnA.Checked)
                    {
                        rBtnU.Checked = false;
                        status = 1;
                    }
                    else if (rBtnU.Checked)
                    {
                        rBtnA.Checked = false;
                        status = 0;
                    }

                    
                    string cmd = string.Format("insert into usuarios (nombre, account, psw,status_admin) values ('{0}','{1}','{2}','{3}')", nombre, usuario, psw2, status);
                    Utilidades.Ejecutar(cmd);                  
                    txtNombre.ResetText();
                    txtUsuario.ResetText();
                    txtPsw1.ResetText();
                    txtpsw2.ResetText();
                    txtBuscar.ResetText();
                    groupBox1.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Contraseñas no coinciden, revise los campos");
                    txtNombre.ResetText();
                    txtUsuario.ResetText();
                    txtPsw1.ResetText();
                    txtpsw2.ResetText();
                    txtBuscar.ResetText();
                    groupBox1.Enabled = false;
                }
            }catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            DGVUsuarios.DataSource = llenadoDGV("usuarios").Tables[0];
        }

        private void rBtnA_CheckedChanged(object sender, EventArgs e)
        {
            //borrar
        }

        private void btnBuscarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                
                string cmd = string.Format("select * from usuarios where account = '" + txtBuscar.Text + "'");
                DataSet ds = Utilidades.Ejecutar(cmd);


                busquedaUsuario = txtBuscar.Text;
                string cuenta = ds.Tables[0].Rows[0]["account"].ToString().Trim();
                string password = ds.Tables[0].Rows[0]["psw"].ToString().Trim();
                string nombre = ds.Tables[0].Rows[0]["nombre"].ToString().Trim();
                string status = ds.Tables[0].Rows[0]["status_admin"].ToString().Trim();

               
                txtMU.Text = cuenta;
                txtMN.Text = nombre;
                txtMC.Text = password;
                txtMC2.Text = password;
                groupBox1.Enabled = true;
            }
            catch (Exception err)
            {
                MessageBox.Show("Usuario no existe");
            }
        }

        private void button50_Click(object sender, EventArgs e)
        {
            
           
            //int status = Convert.ToInt32(txtP_stock.Text);
            //decimal pP = Convert.ToDecimal(txtP_Precio.Text);
            int statusModificarUsuario=0;
            if (rBtbMA.Checked)
            {
                statusModificarUsuario = 1;
                modificarUsuario(statusModificarUsuario);
                
            }
            else if (rBtbMU.Checked)
            {
                statusModificarUsuario = 0;
                modificarUsuario(statusModificarUsuario);
                
            }
            else
            {
                MessageBox.Show("Selecciona tipo de usuario!");
            }
            DGVUsuarios.DataSource = llenadoDGV("usuarios").Tables[0];


        }
        public void modificarUsuario(int s)
        {
            string nombre = txtMN.Text;
            string account = txtMU.Text;
            string password1 = txtMC.Text;
            string password2 = txtMC2.Text;
            
            try
            {
                if (password1 == password2)
                {

                    string cmd = string.Format("update usuarios set nombre = '{0}', account = '{1}',psw ='{2}' , status_admin = '{3}' where account = '{4}'", nombre, account, password2, s, busquedaUsuario);

                    DataSet ds = Utilidades.Ejecutar(cmd);
                    txtMU.ResetText();
                    txtMN.ResetText();
                    txtMC.ResetText();
                    txtMC2.ResetText();
                    txtBuscar.ResetText();
                    groupBox1.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Contraseñas no coinciden, revise los campos");
                    txtMU.ResetText();
                    txtMN.ResetText();
                    txtMC.ResetText();
                    txtMC2.ResetText();
                    txtBuscar.ResetText();
                    groupBox1.Enabled = false;
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                MessageBox.Show("Llame al administrador para soporte del sistema");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string cmd = string.Format("delete from usuarios where account = '{0}'", busquedaUsuario);
            DataSet ds = Utilidades.Ejecutar(cmd);
            txtMU.ResetText();
            txtMN.ResetText();
            txtMC.ResetText();
            txtMC2.ResetText();
            txtBuscar.ResetText();
            groupBox1.Enabled = false;
            DGVUsuarios.DataSource = llenadoDGV("usuarios").Tables[0];
        }

#region BOTONES VENTAS


        public void totalPLLEVAR() 
        {
            int contador = DGV_V_L.Rows.Count;
            
            for (int i = 0; i < contador ; i++)
            {
                try
                {
                    totalPLL += Convert.ToDecimal(DGV_V_L.Rows[i].Cells[4].Value.ToString());
                }
                catch (Exception)
                {
                    totalPLL += 0;
                    MessageBox.Show("Nada se cor");
                }
            }
            lblTotalLlevar.Text = Convert.ToString("$" + totalPLL);
            
        }






        #region METOOS PARA AGREGAR A DATA GRID VIEW

        public void agregarPLL(int p) //METODO PARA LLEVAR
        {
            bool existe = false;
            int num_fila = 0;

            string descripcion;
            int stock = 0, id_producto, cantidad = 0;
            decimal precio, importe = 0;

            string cmd = string.Format("Select * from productos where id_producto  ='{0}'", p);
            DataSet ds = Utilidades.Ejecutar(cmd);

            id_producto = Convert.ToInt32(ds.Tables[0].Rows[0]["id_producto"].ToString().Trim());
            descripcion = ds.Tables[0].Rows[0]["descripcion"].ToString().Trim();
            stock = Convert.ToInt32(ds.Tables[0].Rows[0]["stock"].ToString().Trim());
            precio = Convert.ToDecimal(ds.Tables[0].Rows[0]["precio"].ToString().Trim());

            if (stock <= 0)
            {
                MessageBox.Show("Inventario insuficiente!");
            }
            else
            {
                if (contF_LL>0)
                {
                    stock = stock - 1;
                    cantidad = cantidad + 1;
                    importe = cantidad * precio;
                    DGV_V_L.Rows.Add(p, descripcion, stock, cantidad, precio, importe);
                    contF_LL++;

                   // cmd = string.Format("update productos set stock = '{0}' where id_producto = '{1}'",stock, id_producto);
                   // ds = Utilidades.Ejecutar(cmd); 
                }
                else
                {
                    foreach (DataGridViewRow fila in DGV_V_L.Rows)
                    {
                        if (fila.Cells[1].Value.ToString() == descripcion)
                        {
                            existe = true;
                            num_fila = fila.Index;
                        }
                    }
                    if (existe == true)
                    {

                        DGV_V_L.Rows[num_fila].Cells[3].Value = (Convert.ToDouble(DGV_V_L.Rows[num_fila].Cells[3].Value) + 1).ToString();
                        stock = Convert.ToInt32(DGV_V_L.Rows[num_fila].Cells[2].Value);
                        DGV_V_L.Rows[num_fila].Cells[2].Value = (Convert.ToInt32(DGV_V_L.Rows[num_fila].Cells[2].Value) - 1);
                        DGV_V_L.Rows[num_fila].Cells[5].Value = (Convert.ToInt32(DGV_V_L.Rows[num_fila].Cells[3].Value) * Convert.ToDecimal(DGV_V_L.Rows[num_fila].Cells[4].Value));

                        //cmd = string.Format("update productos set stock = '{0}' where id_producto = '{1}'", stock, id_producto);
                        //ds = Utilidades.Ejecutar(cmd);
                    }
                    else
                    {
                        stock = stock - 1;
                        cantidad = cantidad + 1;
                        importe = cantidad * precio;
                        DGV_V_L.Rows.Add(p, descripcion, stock, cantidad, precio, importe);

                        // cmd = string.Format("update productos set stock = '{0}' where id_producto = '{1}'", stock, id_producto);
                        //ds = Utilidades.Ejecutar(cmd);

                        contF_LL++;
                    }
                }
                totalLlevar = 0;
                foreach (DataGridViewRow fila in DGV_V_L.Rows)
                {
                    totalLlevar += Convert.ToDecimal(fila.Cells[5].Value);
                }

                lblTotalLlevar.Text = "$ " + totalLlevar.ToString();


                //Articulos 
                artLlevar = 0;
                foreach (DataGridViewRow fila in DGV_V_L.Rows)
                {
                    artLlevar += Convert.ToInt32(fila.Cells[3].Value);
                }

                lblArtLlevar.Text = artLlevar.ToString();
            }
        }

        public void agregarPP(int p)  // METODO PARA PEDIDOS
        {
            bool existe = false;
            int num_fila = 0;

            string descripcion;
            int  id_producto, cantidad = 0;
            decimal precio, importe = 0;

            string cmd = string.Format("Select * from productos where id_producto  ='{0}'", p);
            DataSet ds = Utilidades.Ejecutar(cmd);

            id_producto = Convert.ToInt32(ds.Tables[0].Rows[0]["id_producto"].ToString().Trim());
            descripcion = ds.Tables[0].Rows[0]["descripcion"].ToString().Trim();
            precio = Convert.ToDecimal(ds.Tables[0].Rows[0]["precio"].ToString().Trim());

                if (contF_P == 0 )
                {                           
                        cantidad = cantidad + 1;
                        importe = cantidad * precio;
                        DGV_V_P.Rows.Add(p, descripcion, cantidad, precio, importe);

                contF_P++;
                    
                }
                else
                {
                    foreach (DataGridViewRow fila in DGV_V_P.Rows)
                    {
                        if (fila.Cells[1].Value.ToString() == descripcion)
                        {
                            existe = true;
                            num_fila = fila.Index;
                        }
                    }
                    if (existe == true)
                    {
                        cantidad = cantidad + 1;
                        importe = cantidad * precio;
                        DGV_V_P.Rows[num_fila].Cells[2].Value = (Convert.ToDouble(DGV_V_P.Rows[num_fila].Cells[2].Value) + 1).ToString();
                        DGV_V_P.Rows[num_fila].Cells[4].Value = (Convert.ToInt32(DGV_V_P.Rows[num_fila].Cells[2].Value) * Convert.ToDecimal(DGV_V_P.Rows[num_fila].Cells[3].Value));
                    }
                    else
                    {
                        cantidad = cantidad + 1;
                        importe = cantidad * precio;
                        DGV_V_P.Rows.Add(p, descripcion, cantidad, precio, importe);

                    contF_P++;
                    }
                }
                TotalPedido = 0;
                foreach (DataGridViewRow fila in DGV_V_P.Rows)
                {
                    TotalPedido += Convert.ToDecimal(fila.Cells[4].Value);
                }

                lblTotalPedido.Text = "$ " + TotalPedido.ToString();

                //Articulos 
                artPedido = 0;
                foreach (DataGridViewRow fila in DGV_V_P.Rows)
                {
                    artPedido += Convert.ToInt32(fila.Cells[2].Value);
                }

                lblArtPedido.Text = artPedido.ToString();
            }
        

        public void agregarMesaA(int p) // METODO PARA MESA A
        {
            bool existe = false;
            int num_fila = 0;

            string descripcion;
            int stock = 0, id_producto, cantidad = 0;
            decimal precio, importe = 0;

            string cmd = string.Format("Select * from productos where id_producto  ='{0}'", p);
            DataSet ds = Utilidades.Ejecutar(cmd);

            id_producto = Convert.ToInt32(ds.Tables[0].Rows[0]["id_producto"].ToString().Trim());
            descripcion = ds.Tables[0].Rows[0]["descripcion"].ToString().Trim();
            stock = Convert.ToInt32(ds.Tables[0].Rows[0]["stock"].ToString().Trim());
            precio = Convert.ToDecimal(ds.Tables[0].Rows[0]["precio"].ToString().Trim());

            if (stock <= 0)
            {
                MessageBox.Show("Inventario insuficiente!");
            }
            else
            {

                if (contF_MA == 0)
                {
                    stock = stock - 1;
                    cantidad = cantidad + 1;
                    importe = cantidad * precio;
                    DGV_V_MA.Rows.Add(p, descripcion, stock, cantidad, precio, importe);

                    contF_MA++;
                }
                else
                {
                    foreach (DataGridViewRow fila in DGV_V_MA.Rows)
                    {
                        if (fila.Cells[1].Value.ToString() == descripcion)
                        {
                            existe = true;
                            num_fila = fila.Index;
                        }
                    }
                    if (existe == true)
                    {
                        stock = stock - 1;
                        cantidad = cantidad + 1;
                        importe = cantidad * precio;
                        DGV_V_MA.Rows[num_fila].Cells[3].Value = (Convert.ToDouble(DGV_V_MA.Rows[num_fila].Cells[3].Value) + 1).ToString();
                        DGV_V_MA.Rows[num_fila].Cells[2].Value = (Convert.ToInt32(DGV_V_MA.Rows[num_fila].Cells[2].Value) - 1);
                        DGV_V_MA.Rows[num_fila].Cells[5].Value = (Convert.ToInt32(DGV_V_MA.Rows[num_fila].Cells[3].Value) * Convert.ToDecimal(DGV_V_MA.Rows[num_fila].Cells[4].Value));
                    }
                    else
                    {
                        stock = stock - 1;
                        cantidad = cantidad + 1;
                        importe = cantidad * precio;
                        DGV_V_MA.Rows.Add(p, descripcion, stock, cantidad, precio, importe);

                        contF_MA++;
                    }
                }
                TotalMesaA = 0;
                foreach (DataGridViewRow fila in DGV_V_MA.Rows)
                {
                    TotalMesaA += Convert.ToDecimal(fila.Cells[5].Value);
                }

                lblTotalMesa.Text = "$ " + TotalMesaA.ToString();

                //ARTICULOS
                artMesaA = 0;
                foreach (DataGridViewRow fila in DGV_V_MA.Rows)
                {
                    artMesaA += Convert.ToInt32(fila.Cells[3].Value);
                }

                lblArtMesa.Text = artMesaA.ToString();
            }
        }

        public void agregarMesaB(int p) // METODO PARA MESA B 
        {
            bool existe = false;
            int num_fila = 0;

            string descripcion;
            int stock = 0, id_producto, cantidad = 0;
            decimal precio, importe = 0;

            string cmd = string.Format("Select * from productos where id_producto  ='{0}'", p);
            DataSet ds = Utilidades.Ejecutar(cmd);

            id_producto = Convert.ToInt32(ds.Tables[0].Rows[0]["id_producto"].ToString().Trim());
            descripcion = ds.Tables[0].Rows[0]["descripcion"].ToString().Trim();
            stock = Convert.ToInt32(ds.Tables[0].Rows[0]["stock"].ToString().Trim());
            precio = Convert.ToDecimal(ds.Tables[0].Rows[0]["precio"].ToString().Trim());

            if (stock <= 0)
            {
                MessageBox.Show("Inventario insuficiente!");
            }
            else
            {

                if (contF_MB ==0)
                {
                    stock = stock - 1;
                    cantidad = cantidad + 1;
                    importe = cantidad * precio;
                    DGV_V_MB.Rows.Add(p, descripcion, stock, cantidad, precio, importe);

                    contF_MB++;
                }
                else
                {
                    foreach (DataGridViewRow fila in DGV_V_MB.Rows)
                    {
                        if (fila.Cells[1].Value.ToString() == descripcion)
                        {
                            existe = true;
                            num_fila = fila.Index;
                        }
                    }
                    if (existe == true)
                    {
                        stock = stock - 1;
                        cantidad = cantidad + 1;
                        importe = cantidad * precio;
                        DGV_V_MB.Rows[num_fila].Cells[3].Value = (Convert.ToDouble(DGV_V_MB.Rows[num_fila].Cells[3].Value) + 1).ToString();
                        DGV_V_MB.Rows[num_fila].Cells[2].Value = (Convert.ToInt32(DGV_V_MB.Rows[num_fila].Cells[2].Value) - 1);
                        DGV_V_MB.Rows[num_fila].Cells[5].Value = (Convert.ToInt32(DGV_V_MB.Rows[num_fila].Cells[3].Value) * Convert.ToDecimal(DGV_V_MB.Rows[num_fila].Cells[4].Value));
                    }
                    else
                    {
                        stock = stock - 1;
                        cantidad = cantidad + 1;
                        importe = cantidad * precio;
                        DGV_V_MB.Rows.Add(p, descripcion, stock, cantidad, precio, importe);

                        contF_MB++;
                    }
                }
                TotalMesaB = 0;
                foreach (DataGridViewRow fila in DGV_V_MB.Rows)
                {
                    TotalMesaB += Convert.ToDecimal(fila.Cells[5].Value);
                }

                lblTotalMesa.Text = "$ " + TotalMesaB.ToString();
                //ARTICULOS
                artMesaB = 0;
                foreach (DataGridViewRow fila in DGV_V_MB.Rows)
                {
                    artMesaB += Convert.ToInt32(fila.Cells[3].Value);
                }

                lblArtMesa.Text = artMesaB.ToString();
            }
        }

        public void agregarMesaC(int p) // METODO PARA MESA C 
        {
            bool existe = false;
            int num_fila = 0;

            string descripcion;
            int stock = 0, id_producto, cantidad = 0;
            decimal precio, importe = 0;

            string cmd = string.Format("Select * from productos where id_producto  ='{0}'", p);
            DataSet ds = Utilidades.Ejecutar(cmd);

            id_producto = Convert.ToInt32(ds.Tables[0].Rows[0]["id_producto"].ToString().Trim());
            descripcion = ds.Tables[0].Rows[0]["descripcion"].ToString().Trim();
            stock = Convert.ToInt32(ds.Tables[0].Rows[0]["stock"].ToString().Trim());
            precio = Convert.ToDecimal(ds.Tables[0].Rows[0]["precio"].ToString().Trim());

            if (stock <= 0)
            {
                MessageBox.Show("Inventario insuficiente!");
            }
            else
            {

                if (contF_MC ==0)
                {
                    stock = stock - 1;
                    cantidad = cantidad + 1;
                    importe = cantidad * precio;
                    DGV_V_MC.Rows.Add(p, descripcion, stock, cantidad, precio, importe);

                    contF_MC++;
                }
                else
                {
                    foreach (DataGridViewRow fila in DGV_V_MC.Rows)
                    {
                        if (fila.Cells[1].Value.ToString() == descripcion)
                        {
                            existe = true;
                            num_fila = fila.Index;
                        }
                    }
                    if (existe == true)
                    {
                        stock = stock - 1;
                        cantidad = cantidad + 1;
                        importe = cantidad * precio;
                        DGV_V_MC.Rows[num_fila].Cells[3].Value = (Convert.ToDouble(DGV_V_MC.Rows[num_fila].Cells[3].Value) + 1).ToString();
                        DGV_V_MC.Rows[num_fila].Cells[2].Value = (Convert.ToInt32(DGV_V_MC.Rows[num_fila].Cells[2].Value) - 1);
                        DGV_V_MC.Rows[num_fila].Cells[5].Value = (Convert.ToInt32(DGV_V_MC.Rows[num_fila].Cells[3].Value) * Convert.ToDecimal(DGV_V_MC.Rows[num_fila].Cells[4].Value));
                    }
                    else
                    {
                        stock = stock - 1;
                        cantidad = cantidad + 1;
                        importe = cantidad * precio;
                        DGV_V_MC.Rows.Add(p, descripcion, stock, cantidad, precio, importe);

                        contF_MC++;
                    }
                }
                TotalMesaC = 0;
                foreach (DataGridViewRow fila in DGV_V_MC.Rows)
                {
                    TotalMesaC += Convert.ToDecimal(fila.Cells[5].Value);
                }

                lblTotalMesa.Text = "$ " + TotalMesaC.ToString();

                //sin terminar?? que es esto alv?
                artMesaC = 0;
                foreach (DataGridViewRow fila in DGV_V_MC.Rows)
                {
                    artMesaC += Convert.ToInt32(fila.Cells[3].Value);
                }

                lblArtMesa.Text = artMesaC.ToString();


            }
        }

        public void articuloComun()
        {
            if(tipoVenta == 1)//Tipo de venta Para llevar
            {
                bool existe = false;
                int num_fila = 0;

                string descripcion;
                int stock = 0, id_producto, cantidad = 0;
                decimal precio, importe = 0;

                id_producto = 0000;
                descripcion = Convert.ToString(txtDescripcionAC.Text);
                stock = 0;
                precio = Convert.ToDecimal(txtPrecioAC.Text);
                cantidad = Convert.ToInt32(txtCantidadAC.Text);
                importe = cantidad * precio;


                if (contF_LL==0)
                {
                    DGV_V_L.Rows.Add(id_producto, descripcion, stock, cantidad, precio, importe);
                    contF_LL++;
                }
                else
                {
                    foreach (DataGridViewRow fila in DGV_V_L.Rows)
                    {
                        if (fila.Cells[1].Value.ToString() == descripcion)
                        {
                            existe = true;
                            num_fila = fila.Index;
                        }
                    }
                    if (existe == true)
                    {

                        MessageBox.Show("Articulo ya existe, eliminelo y vuelva a ingresarlo");
                    }
                    else
                    {
                        DGV_V_L.Rows.Add(id_producto, descripcion, stock, cantidad, precio, importe);
                        contF_LL++;
                    }
                }
                totalLlevar = 0;
                foreach (DataGridViewRow fila in DGV_V_L.Rows)
                {
                    totalLlevar += Convert.ToDecimal(fila.Cells[5].Value);
                }

                lblTotalLlevar.Text = "$ " + totalLlevar.ToString();

                //Articulos 
                artLlevar = 0;
                foreach (DataGridViewRow fila in DGV_V_L.Rows)
                {
                    artLlevar += Convert.ToInt32(fila.Cells[3].Value);
                }

                lblArtLlevar.Text = artLlevar.ToString();

            }
            else if (tipoVenta == 2)
            {
                if(MesaSeleccionada== 0)// Mesa A
                {
                    bool existe = false;
                    int num_fila = 0;

                    string descripcion;
                    int stock = 0, id_producto, cantidad = 0;
                    decimal precio, importe = 0;

                    id_producto = 0000;
                    descripcion = Convert.ToString(txtDescripcionAC.Text);
                    stock = 0;
                    precio = Convert.ToDecimal(txtPrecioAC.Text);
                    cantidad = Convert.ToInt32(txtCantidadAC.Text);
                    importe = cantidad * precio;


                    if (contF_MA ==0)
                    {
                        DGV_V_MA.Rows.Add(id_producto, descripcion, stock, cantidad, precio, importe);
                        contF_MA++;
                    }
                    else
                    {
                        foreach (DataGridViewRow fila in DGV_V_MA.Rows)
                        {
                            if (fila.Cells[1].Value.ToString() == descripcion)
                            {
                                existe = true;
                                num_fila = fila.Index;
                            }
                        }
                        if (existe == true)
                        {

                            MessageBox.Show("Articulo ya existe, eliminelo y vuelva a ingresarlo");
                        }
                        else
                        {
                            DGV_V_MA.Rows.Add(id_producto, descripcion, stock, cantidad, precio, importe);
                            contF_MA++;
                        }
                    }
                    TotalMesaA = 0;
                    foreach (DataGridViewRow fila in DGV_V_MA.Rows)
                    {
                        TotalMesaA += Convert.ToDecimal(fila.Cells[5].Value);
                    }

                    lblTotalMesa.Text = "$ " + TotalMesaA.ToString();

                    //Articulos 
                    artMesaA = 0;
                    foreach (DataGridViewRow fila in DGV_V_MA.Rows)
                    {
                        artMesaA += Convert.ToInt32(fila.Cells[3].Value);
                    }

                    lblArtMesa.Text = artMesaA.ToString();
                }
                else if (MesaSeleccionada == 1)//Mesa B
                {
                    bool existe = false;
                    int num_fila = 0;

                    string descripcion;
                    int stock = 0, id_producto, cantidad = 0;
                    decimal precio, importe = 0;

                    id_producto = 0000;
                    descripcion = Convert.ToString(txtDescripcionAC.Text);
                    stock = 0;
                    precio = Convert.ToDecimal(txtPrecioAC.Text);
                    cantidad = Convert.ToInt32(txtCantidadAC.Text);
                    importe = cantidad * precio;


                    if (contF_MB == 0)
                    {
                        DGV_V_MB.Rows.Add(id_producto, descripcion, stock, cantidad, precio, importe);
                        contF_MB++;
                    }
                    else
                    {
                        foreach (DataGridViewRow fila in DGV_V_MB.Rows)
                        {
                            if (fila.Cells[1].Value.ToString() == descripcion)
                            {
                                existe = true;
                                num_fila = fila.Index;
                            }
                        }
                        if (existe == true)
                        {

                            MessageBox.Show("Articulo ya existe, eliminelo y vuelva a ingresarlo");
                        }
                        else
                        {
                            DGV_V_MB.Rows.Add(id_producto, descripcion, stock, cantidad, precio, importe);
                            contF_MB++;
                        }
                    }
                    TotalMesaB = 0;
                    foreach (DataGridViewRow fila in DGV_V_MB.Rows)
                    {
                        TotalMesaB += Convert.ToDecimal(fila.Cells[5].Value);
                    }

                    lblTotalMesa.Text = "$ " + TotalMesaB.ToString();

                    //Articulos 
                    artMesaB = 0;
                    foreach (DataGridViewRow fila in DGV_V_MB.Rows)
                    {
                        artMesaB += Convert.ToInt32(fila.Cells[3].Value);
                    }

                    lblArtMesa.Text = artMesaB.ToString();

                }
                else if (MesaSeleccionada == 2)//Mesa C
                {
                    bool existe = false;
                    int num_fila = 0;

                    string descripcion;
                    int stock = 0, id_producto, cantidad = 0;
                    decimal precio, importe = 0;

                    id_producto = 0000;
                    descripcion = Convert.ToString(txtDescripcionAC.Text);
                    stock = 0;
                    precio = Convert.ToDecimal(txtPrecioAC.Text);
                    cantidad = Convert.ToInt32(txtCantidadAC.Text);
                    importe = cantidad * precio;


                    if (contF_MC == 0)
                    {
                        DGV_V_MC.Rows.Add(id_producto, descripcion, stock, cantidad, precio, importe);
                        contF_MC++;
                    }
                    else
                    {
                        foreach (DataGridViewRow fila in DGV_V_MC.Rows)
                        {
                            if (fila.Cells[1].Value.ToString() == descripcion)
                            {
                                existe = true;
                                num_fila = fila.Index;
                            }
                        }
                        if (existe == true)
                        {

                            MessageBox.Show("Articulo ya existe, eliminelo y vuelva a ingresarlo");
                        }
                        else
                        {
                            DGV_V_MC.Rows.Add(id_producto, descripcion, stock, cantidad, precio, importe);
                            contF_MC++;
                        }
                    }
                    TotalMesaC = 0;
                    foreach (DataGridViewRow fila in DGV_V_MC.Rows)
                    {
                        TotalMesaC += Convert.ToDecimal(fila.Cells[5].Value);
                    }

                    lblTotalMesa.Text = "$ " + TotalMesaC.ToString();

                    //Articulos 
                    artMesaC = 0;
                    foreach (DataGridViewRow fila in DGV_V_MC.Rows)
                    {
                        artMesaC += Convert.ToInt32(fila.Cells[3].Value);
                    }

                    lblArtMesa.Text = artMesaC.ToString();
                }

            } else if (tipoVenta == 3)// Tipo de venta Pedido
            {

                bool existe = false;
                int num_fila = 0;

                string descripcion;
                int stock = 0, id_producto, cantidad = 0;
                decimal precio, importe = 0;

                id_producto = 0000;
                descripcion = Convert.ToString(txtDescripcionAC.Text);
                stock = 0;
                precio = Convert.ToDecimal(txtPrecioAC.Text);
                cantidad = Convert.ToInt32(txtCantidadAC.Text);
                importe = cantidad * precio;


                if (contF_P==0)
                {
                    DGV_V_P.Rows.Add(id_producto, descripcion, stock, cantidad, precio, importe);
                    contF_P++;
                
                }
                else
                {
                    foreach (DataGridViewRow fila in DGV_V_P.Rows)
                    {
                        if (fila.Cells[1].Value.ToString() == descripcion)
                        {
                            existe = true;
                            num_fila = fila.Index;
                        }
                    }
                    if (existe == true)
                    {

                        MessageBox.Show("Articulo ya existe, eliminelo y vuelva a ingresarlo");
                    }
                    else
                    {
                        DGV_V_P.Rows.Add(id_producto, descripcion, stock, cantidad, precio, importe);
                        contF_P++;
                    }
                }
                TotalPedido = 0;
                foreach (DataGridViewRow fila in DGV_V_P.Rows)
                {
                    TotalPedido += Convert.ToDecimal(fila.Cells[4].Value);
                }

                lblTotalPedido.Text = "$ " + TotalPedido.ToString();

                //Articulos 
                artPedido = 0;
                foreach (DataGridViewRow fila in DGV_V_P.Rows)
                {
                    artPedido += Convert.ToInt32(fila.Cells[3].Value);
                }

                lblArtPedido.Text = artPedido.ToString();

            }
        }

        #endregion


        #region Botones de articulos
        private void btnAsadoRojo_Click(object sender, EventArgs e)
        {
            int p = 1;
            if (tipoVenta == 1)
            {
                agregarPLL(p);
            }
            else if (tipoVenta == 2)
            {
                if (MesaSeleccionada == 0)
                {
                    agregarMesaA(p);
                }
                else if (MesaSeleccionada == 1)
                {
                    agregarMesaB(p);
                }
                else if (MesaSeleccionada == 2)
                {
                    agregarMesaC(p);
                }
            }
            else if (tipoVenta == 3)
            {
                agregarPP(p);
            }
        }

        private void btnRajas_Click(object sender, EventArgs e)
        {
            int p = 2;
            if (tipoVenta == 1)
            {
                agregarPLL(p);
            }
            else if (tipoVenta == 2)
            {
                if (MesaSeleccionada == 0)
                {
                    agregarMesaA(p);
                }
                else if (MesaSeleccionada == 1)
                {
                    agregarMesaB(p);
                }
                else if (MesaSeleccionada == 2)
                {
                    agregarMesaC(p);
                }
            }
            else if (tipoVenta == 3)
            {
                agregarPP(p);
            }
        }

        
        private void btnSalsaVerde_Click(object sender, EventArgs e)
        {
            int p = 3;
            if (tipoVenta == 1)
            {
                agregarPLL(p);
            }
            else if (tipoVenta == 2)
            {
                if (MesaSeleccionada == 0)
                {
                    agregarMesaA(p);
                }
                else if (MesaSeleccionada == 1)
                {
                    agregarMesaB(p);
                }
                else if (MesaSeleccionada == 2)
                {
                    agregarMesaC(p);
                }
            }
            else if (tipoVenta == 3)
            {
                agregarPP(p);
            }

        }

        private void btnChicharron_Click(object sender, EventArgs e)
        {
            int p = 4;
            if (tipoVenta == 1)
            {
                agregarPLL(p);
            } 
            else if (tipoVenta == 2)
            {
                if (MesaSeleccionada == 0)
                {
                    agregarMesaA(p);
                }
                else if (MesaSeleccionada == 1)
                {
                    agregarMesaB(p);
                }
                else if (MesaSeleccionada == 2)
                {
                    agregarMesaC(p);
                }
            }
            else if ( tipoVenta == 3)
            {
                agregarPP(p);
            }
        }

        private void btnAsadoVerde_Click(object sender, EventArgs e)
        {
            int p = 5;
            if (tipoVenta == 1)
            {              
                agregarPLL(p);
            }
            else if (tipoVenta == 2)
            {
                if (MesaSeleccionada == 0)
                {
                    agregarMesaA(p);
                }
                else if (MesaSeleccionada == 1)
                {
                    agregarMesaB(p);
                }
                else if (MesaSeleccionada == 2)
                {
                    agregarMesaC(p);
                }
            }
            else if (tipoVenta == 3)
            {
                agregarPP(p);
            }
        }

        private void btnPina_Click(object sender, EventArgs e)
        {
                int p = 6;
            if (tipoVenta == 1)
            {
                agregarPLL(p);
            }
            else if (tipoVenta == 2)
            {
                if (MesaSeleccionada == 0)
                {
                    agregarMesaA(p);
                }
                else if (MesaSeleccionada == 1)
                {
                    agregarMesaB(p);
                }
                else if (MesaSeleccionada == 2)
                {
                    agregarMesaC(p);
                }
            }
            else if (tipoVenta == 3)
            {
                agregarPP(p);
            }
        }

        private void btnFresa_Click(object sender, EventArgs e)
        {
                int p = 7;
            if (tipoVenta == 1)
            {
                agregarPLL(p);
            }
            else if (tipoVenta == 2)
            {
                if (MesaSeleccionada == 0)
                {
                    agregarMesaA(p);
                }
                else if (MesaSeleccionada == 1)
                {
                    agregarMesaB(p);
                }
                else if (MesaSeleccionada == 2)
                {
                    agregarMesaC(p);
                }
            }
            else if (tipoVenta == 3)
            {
                agregarPP(p);
            }
        }

        private void btnCajeta_Click(object sender, EventArgs e)
        {
                int p = 8;
            if (tipoVenta == 1)
            {
                agregarPLL(p);
            }
            else if (tipoVenta == 2)
            {
                if (MesaSeleccionada == 0)
                {
                    agregarMesaA(p);
                }
                else if (MesaSeleccionada == 1)
                {
                    agregarMesaB(p);
                }
                else if (MesaSeleccionada == 2)
                {
                    agregarMesaC(p);
                }
            }
            else if (tipoVenta == 3)
            {
                agregarPP(p);
            }
        }

        private void btnZarzamora_Click(object sender, EventArgs e)
        {
                int p = 9;
            if (tipoVenta == 1)
            {
                agregarPLL(p);
            }
            else if (tipoVenta == 2)
            {
                if (MesaSeleccionada == 0)
                {
                    agregarMesaA(p);
                }
                else if (MesaSeleccionada == 1)
                {
                    agregarMesaB(p);
                }
                else if (MesaSeleccionada == 2)
                {
                    agregarMesaC(p);
                }
            }
            else if (tipoVenta == 3)
            {
                agregarPP(p);
            }
        }

        #endregion

        private void button4_Click_1(object sender, EventArgs e)
        {
            pnlArtCom.Hide();
            txtDescripcionAC.Text = "";
            txtCantidadAC.Text = "";
            txtPrecioAC.Text = "";
        }

        private void btnAgregarArtComun_Click(object sender, EventArgs e)
        {
            if (txtDescripcionAC.Text == "" || txtPrecioAC.Text == "" || txtCantidadAC.Text == "")
            {
                MessageBox.Show("Ingrese lo datos: Descripcion, precio y cantidad para agregar");
            }
            else
            {
                articuloComun();
                pnlArtCom.Hide();
                txtDescripcionAC.Text = "";
                txtCantidadAC.Text = "";
                txtPrecioAC.Text = "";
            }
        }

        private void txtCantidadAC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsNumber(e.KeyChar) || e.KeyChar == (int)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPrecioAC_Validating(object sender, CancelEventArgs e)
        {
            //borrar oasmdoiasd
        }

        private void txtPrecioAC_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtP_stock_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtP_Precio_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
         Utilidades ut = new Utilidades();
            string cmd = string.Format("Select * from Ventas where fecha = '{0}' ", ut.FormatoFecha(dateTimePicker1));
            DataSet ds = Utilidades.Ejecutar(cmd);
           DGV_R_R.DataSource = ds;

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        void DespuesdeCobrar()
        {
            pnlCobrarPlL.Hide();
            button24.Enabled = true;
            txtPago.Text = "";
            lblCambio.Text = "";

        }

        private void button2_Click_2(object sender, EventArgs e) //COBRAR CON TICKET LLEVAR Y MESAS)
        {
            if (pago <= 0 || cambio <0)
            {
                MessageBox.Show("Ingrese con la cantidad que pago el cliente!");
            }
            else
            {
                if (tipoVenta == 1) //TIPO DE VENTA PARA LLEVAR 
                {

                    Modo = 0;
                    int cant = Convert.ToInt32(artLlevar);
                    decimal total = Convert.ToDecimal(totalLlevar);



                    if (contF_LL != 0)
                    {

                        try
                        {
                            string cmd = string.Format("insert into Ventas (tipo_venta,cantidad,fecha,hora,total) values ({0},{1},GETDATE(), CURRENT_TIMESTAMP,{2} );", tipoVenta, cant, total);
                            Utilidades.Ejecutar(cmd);
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message);
                        }

                        try
                        {

                            string cmd = string.Format("Exec ActualizaFacturas'{0}'", usuario);

                            DataSet ds = Utilidades.Ejecutar(cmd);

                            string NumFac = ds.Tables[0].Rows[0]["NumFac"].ToString().Trim();

                            foreach (DataGridViewRow F in DGV_V_L.Rows)
                            {
                                cmd = string.Format("Exec ActualizaDetalles'{0}','{1}','{2}','{3}'", NumFac, F.Cells[0].Value.ToString(), F.Cells[4].Value.ToString(), F.Cells[3].Value.ToString());
                                ds = Utilidades.Ejecutar(cmd);
                            }

                            string cmds = "Exec DatosFactura " + NumFac.ToString();

                            ds = Utilidades.Ejecutar(cmds);

                            //ventana reporte
                            ReportePrueba fc = new ReportePrueba();
                            //     fc.Show();
                            fc.reportViewer1.LocalReport.DataSources[0].Value = ds.Tables[0];
                            fc.ShowDialog();
                            contF_LL = 0;


                        }
                        catch (Exception error)
                        {
                            MessageBox.Show(error.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Agrega articulos a la cuenta!");
                    }
                    DGV_V_L.Rows.Clear();
                    artLlevar = 0;
                    totalLlevar = 0;
                    lblArtLlevar.Text = "0";
                    lblTotalLlevar.Text = "0";
                    button23.Enabled = true;
                    button29.Enabled = true;
                    activarProductos();
                }

                if (tipoVenta == 2)// TIPO DE VENTA MESA
                {
                    if (MesaSeleccionada == 0)//MESA A 
                    {
                        Modo = 0;
                        int cant = Convert.ToInt32(artMesaA);
                        decimal total = Convert.ToDecimal(TotalMesaA);




                        if (contF_MA != 0)
                        {
                            try
                            {
                                string cmd = string.Format("insert into Ventas (tipo_venta,cantidad,fecha,hora,total) values ({0},{1},GETDATE(), CURRENT_TIMESTAMP,{2} );", tipoVenta, cant, total);
                                Utilidades.Ejecutar(cmd);
                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message);
                            }

                            try
                            {

                                string cmd = string.Format("Exec ActualizaFacturas'{0}'", usuario);

                                DataSet ds = Utilidades.Ejecutar(cmd);

                                string NumFac = ds.Tables[0].Rows[0]["NumFac"].ToString().Trim();

                                foreach (DataGridViewRow F in DGV_V_MA.Rows)
                                {
                                    cmd = string.Format("Exec ActualizaDetalles'{0}','{1}','{2}','{3}'", NumFac, F.Cells[0].Value.ToString(), F.Cells[4].Value.ToString(), F.Cells[3].Value.ToString());
                                    ds = Utilidades.Ejecutar(cmd);
                                }

                                string cmds = "Exec DatosFactura " + NumFac.ToString();

                                ds = Utilidades.Ejecutar(cmds);

                                //ventana reporte
                                ReportePrueba fc = new ReportePrueba();
                                //     fc.Show();
                                fc.reportViewer1.LocalReport.DataSources[0].Value = ds.Tables[0];
                                fc.ShowDialog();
                                contF_MA = 0;

                            }
                            catch (Exception error)
                            {
                                MessageBox.Show(error.Message);
                            }
                        }


                        DGV_V_MA.Rows.Clear();
                        artMesaA = 0;
                        TotalMesaA = 0;
                        lblArtMesa.Text = "0";
                        lblTotalMesa.Text = "0";
                        btnEliminarMesas.Enabled = true;
                        activarProductos();
                        button29.Enabled = true;


                    }
                    else if (MesaSeleccionada == 1) //MESA B 
                    {
                        Modo = 0;
                        int cant = Convert.ToInt32(artMesaB);
                        decimal total = Convert.ToDecimal(TotalMesaB);




                        if (contF_MB != 0)
                        {
                            try
                            {
                                string cmd = string.Format("insert into Ventas (tipo_venta,cantidad,fecha,hora,total) values ({0},{1},GETDATE(), CURRENT_TIMESTAMP,{2} );", tipoVenta, cant, total);
                                Utilidades.Ejecutar(cmd);
                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message);
                            }

                            try
                            {

                                string cmd = string.Format("Exec ActualizaFacturas'{0}'", usuario);

                                DataSet ds = Utilidades.Ejecutar(cmd);

                                string NumFac = ds.Tables[0].Rows[0]["NumFac"].ToString().Trim();

                                foreach (DataGridViewRow F in DGV_V_MB.Rows)
                                {
                                    cmd = string.Format("Exec ActualizaDetalles'{0}','{1}','{2}','{3}'", NumFac, F.Cells[0].Value.ToString(), F.Cells[4].Value.ToString(), F.Cells[3].Value.ToString());
                                    ds = Utilidades.Ejecutar(cmd);
                                }

                                string cmds = "Exec DatosFactura " + NumFac.ToString();

                                ds = Utilidades.Ejecutar(cmds);

                                //ventana reporte
                                ReportePrueba fc = new ReportePrueba();
                                //     fc.Show();
                                fc.reportViewer1.LocalReport.DataSources[0].Value = ds.Tables[0];
                                fc.ShowDialog();
                                contF_MB = 0;

                            }
                            catch (Exception error)
                            {
                                MessageBox.Show(error.Message);
                            }
                        }
                        DGV_V_MB.Rows.Clear();
                        artMesaB = 0;
                        TotalMesaB = 0;
                        lblArtMesa.Text = "0";
                        lblTotalMesa.Text = "0";
                        btnEliminarMesas.Enabled = true;
                        activarProductos();
                        button29.Enabled = true;


                    }
                    else if (MesaSeleccionada == 2) // MESA C 
                    {
                        Modo = 0;
                        int cant = Convert.ToInt32(artMesaC);
                        decimal total = Convert.ToDecimal(TotalMesaC);




                        if (contF_MC != 0)
                        {
                            try
                            {
                                string cmd = string.Format("insert into Ventas (tipo_venta,cantidad,fecha,hora,total) values ({0},{1},GETDATE(), CURRENT_TIMESTAMP,{2} );", tipoVenta, cant, total);
                                Utilidades.Ejecutar(cmd);
                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message);
                            }

                            try
                            {

                                string cmd = string.Format("Exec ActualizaFacturas'{0}'", usuario);

                                DataSet ds = Utilidades.Ejecutar(cmd);

                                string NumFac = ds.Tables[0].Rows[0]["NumFac"].ToString().Trim();

                                foreach (DataGridViewRow F in DGV_V_MC.Rows)
                                {
                                    cmd = string.Format("Exec ActualizaDetalles'{0}','{1}','{2}','{3}'", NumFac, F.Cells[0].Value.ToString(), F.Cells[4].Value.ToString(), F.Cells[3].Value.ToString());
                                    ds = Utilidades.Ejecutar(cmd);
                                }

                                string cmds = "Exec DatosFactura " + NumFac.ToString();

                                ds = Utilidades.Ejecutar(cmds);

                                //ventana reporte
                                ReportePrueba fc = new ReportePrueba();
                                //     fc.Show();
                                fc.reportViewer1.LocalReport.DataSources[0].Value = ds.Tables[0];
                                fc.ShowDialog();
                                contF_MC = 0;

                            }
                            catch (Exception error)
                            {
                                MessageBox.Show(error.Message);
                            }
                        }
                        DGV_V_MC.Rows.Clear();
                        artMesaC = 0;
                        TotalMesaC = 0;
                        lblArtMesa.Text = "0";
                        lblTotalMesa.Text = "0";
                        btnEliminarMesas.Enabled = true;
                        button29.Enabled = true;
                        activarProductos();

                    }
                }
            }
            btnEliminarMesas.Enabled = true;
            button29.Enabled = true;
            button23.Enabled = true;
            DespuesdeCobrar();
            activarProductos();
        }

        private void button10_Click_1(object sender, EventArgs e) //COBRAR SIN TICKET (LLEVAR Y MESAS)
        {

            if (pago <= 0 || cambio < 0)
            {
                MessageBox.Show("Ingrese con la cantidad que pago el cliente!");
            }
            else
            {
                if (tipoVenta == 1) //cobrar sin ticker llevar 
                {
                    Modo = 0;
                    int cant = Convert.ToInt32(artLlevar);
                    decimal total = Convert.ToDecimal(totalLlevar);

                    if (contF_LL != 0)
                    {
                        try
                        {
                            string cmd = string.Format("insert into Ventas (tipo_venta,cantidad,fecha,hora,total) values ({0},{1},GETDATE(), CURRENT_TIMESTAMP,{2} );", tipoVenta, cant, total);
                            Utilidades.Ejecutar(cmd);
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message);
                        }
                        DGV_V_L.Rows.Clear();
                        artLlevar = 0;
                        totalLlevar = 0;
                        lblArtLlevar.Text = "0";
                        lblTotalLlevar.Text = "0";
                        button23.Enabled = true;
                        contF_LL = 0;
                    }
                    else
                    {
                        MessageBox.Show("No hay articulos que cobrar");
                    }
                }
                else if (tipoVenta == 2)
                {
                    if (MesaSeleccionada == 0) //MESA A
                    {
                        Modo = 0;
                        int cant = Convert.ToInt32(artMesaA);
                        decimal total = Convert.ToDecimal(TotalMesaA);
                        if (contF_MA != 0)
                        {
                            try
                            {
                                string cmd = string.Format("insert into Ventas (tipo_venta,cantidad,fecha,hora,total) values ({0},{1},GETDATE(), CURRENT_TIMESTAMP,{2} );", tipoVenta, cant, total);
                                Utilidades.Ejecutar(cmd);
                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message);
                            }

                            DGV_V_MA.Rows.Clear();
                            artMesaA = 0;
                            TotalMesaA = 0;
                            lblArtMesa.Text = "0";
                            lblTotalMesa.Text = "0";
                            btnEliminarMesas.Enabled = true;

                            activarProductos();
                            button29.Enabled = true;
                            contF_MA = 0;
                        }
                        else
                        {
                            MessageBox.Show("No hay articulos por cobrar");
                        }
                    }
                    else if (MesaSeleccionada == 1)//MESA B 
                    {
                        Modo = 0;
                        int cant = Convert.ToInt32(artMesaB);
                        decimal total = Convert.ToDecimal(TotalMesaB);
                        if (contF_MB != 0)
                        {
                            try
                            {
                                string cmd = string.Format("insert into Ventas (tipo_venta,cantidad,fecha,hora,total) values ({0},{1},GETDATE(), CURRENT_TIMESTAMP,{2} );", tipoVenta, cant, total);
                                Utilidades.Ejecutar(cmd);
                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message);
                            }
                            DGV_V_MB.Rows.Clear();
                            artMesaB = 0;
                            TotalMesaB = 0;
                            lblArtMesa.Text = "0";
                            lblTotalMesa.Text = "0";
                            btnEliminarMesas.Enabled = true;
                            activarProductos();
                            button29.Enabled = true;
                            contF_MB = 0;

                        }
                        else
                        {
                            MessageBox.Show("No hay articulos por cobrar");
                        }
                    }
                    else if (MesaSeleccionada == 2)// MESA C 
                    {
                        Modo = 0;
                        int cant = Convert.ToInt32(artMesaC);
                        decimal total = Convert.ToDecimal(TotalMesaC);
                        if (contF_MC != 0)
                        {
                            try
                            {
                                string cmd = string.Format("insert into Ventas (tipo_venta,cantidad,fecha,hora,total) values ({0},{1},GETDATE(), CURRENT_TIMESTAMP,{2} );", tipoVenta, cant, total);
                                Utilidades.Ejecutar(cmd);
                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message);
                            }
                            DGV_V_MC.Rows.Clear();
                            artMesaB = 0;
                            TotalMesaB = 0;
                            lblArtMesa.Text = "0";
                            lblTotalMesa.Text = "0";
                            btnEliminarMesas.Enabled = true;
                            activarProductos();
                            button29.Enabled = true;
                            contF_MC = 0;
                        }
                        else
                        {
                            MessageBox.Show("No hay articulos por cobrar");
                        }
                    }
                }
            }
            btnEliminarMesas.Enabled = true;
            button29.Enabled = true;
            button23.Enabled = true;
            DespuesdeCobrar();
            activarProductos();
        }

        private void button11_Click(object sender, EventArgs e) //BOTON CANCELAR COBRAR
        {
            DespuesdeCobrar();
            activarProductos();
            button23.Enabled = true;
            button24.Enabled = true;
            btnEliminarMesas.Enabled = true;
            activarProductos();
            button24.Enabled = true;
            btn_CobrarPedido.Enabled = true;

        }

        private void button12_Click(object sender, EventArgs e)// COBRAR PEDIDOS CON TICKET
        {

            if (pago <= 0 || cambio < 0)
            {
                MessageBox.Show("Ingrese con la cantidad que pago el cliente!");
            }
            else
            {
                if (contF_P != 0)
                {
                    if (richTextBox1.Text == "" || richTextBox2.Text == "" || richTextBox3.Text == "")
                    {
                        MessageBox.Show("Llenar todos los campos!");
                    }
                    else
                    {

                        try
                        {
                            string cmd = string.Format("Exec ActualizaFacturas'{0}'", 2);
                            //el 2 es el usuario que le atiende, aqui se debe asignar el usuario que realmente le esta atendiendo 
                            DataSet ds = Utilidades.Ejecutar(cmd);
                            string NumFac = ds.Tables[0].Rows[0]["NumFac"].ToString().Trim();
                            foreach (DataGridViewRow F in DGV_V_P.Rows)
                            {
                                cmd = string.Format("Exec ActualizaDetalles'{0}','{1}','{2}','{3}'", NumFac, F.Cells[0].Value.ToString(), F.Cells[3].Value.ToString(), F.Cells[2].Value.ToString());
                                ds = Utilidades.Ejecutar(cmd);
                            }

                            string cmds = "Exec DatosFactura " + NumFac.ToString();

                            ds = Utilidades.Ejecutar(cmds);

                            //ventana reporte
                            ReportePrueba fc = new ReportePrueba();
                            //     fc.Show();
                            fc.reportViewer1.LocalReport.DataSources[0].Value = ds.Tables[0];
                            fc.ShowDialog();

                        }
                        catch (Exception error)
                        {
                            MessageBox.Show(error.Message);
                        }

                        int cant = Convert.ToInt32(artPedido);
                        decimal total = Convert.ToDecimal(TotalPedido);
                        string nombre = (richTextBox1.Text).ToString().Trim();
                        string direccion = (richTextBox2.Text).ToString().Trim();
                        long celular = Convert.ToInt64(richTextBox3.Text);

                        try
                        {
                            string cmd = string.Format("insert into pedidos (nombre,direccion,celular,cantidad,fecha,hora,total) values ('{0}','{1}',{2},{3},GETDATE(), CURRENT_TIMESTAMP, {4} );", nombre, direccion, celular, cant, total);
                            Utilidades.Ejecutar(cmd);
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message);
                        }

                        try
                        {
                            string cmd = string.Format("insert into Ventas (tipo_venta,cantidad,fecha,hora,total) values ({0},{1},GETDATE(), CURRENT_TIMESTAMP,{2} );", tipoVenta, cant, total);
                            Utilidades.Ejecutar(cmd);
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message);
                        }

                        pnlCobrarPe.Hide();
                        btn_CobrarPedido.Enabled = true;
                        activarProductos();
                        btnEliminarPediddo.Enabled = true;

                        Modo = 0;
                        cant = Convert.ToInt32(artPedido);
                        total = Convert.ToDecimal(TotalPedido);




                        DGV_V_P.Rows.Clear();
                        artPedido = 0;
                        TotalPedido = 0;
                        lblArtPedido.Text = "0";
                        lblTotalPedido.Text = "0";

                        richTextBox1.Text = "";
                        richTextBox2.Text = "";
                        richTextBox3.Text = "";
                        contF_P = 0;



                    }
                }
                else
                {
                    MessageBox.Show("No hay articulos por cobrar");
                }
            }



        }

        private void button13_Click(object sender, EventArgs e) //COBRAR PEDIDOS SIN TICKET 
        {
            if (pago <= 0 || cambio < 0)
            {
                MessageBox.Show("Ingrese con la cantidad que pago el cliente!");
            }
            else
            {
                if (contF_P != 0)
                {
                    if (richTextBox1.Text == "" || richTextBox2.Text == "" || richTextBox3.Text == "")
                    {
                        MessageBox.Show("Llenar todos los campos!");
                    }
                    else
                    {
                        int cant = Convert.ToInt32(artPedido);
                        decimal total = Convert.ToDecimal(TotalPedido);
                        string nombre = richTextBox1.Text;
                        string direccion = richTextBox2.Text;
                        int celular = Convert.ToInt32(richTextBox3.Text);

                        try
                        {
                            string cmd = string.Format("insert into pedidos (nombre,direccion,celular,cantidad,fecha,hora,total) values ('{0}','{1}',{2},{3},GETDATE(), CURRENT_TIMESTAMP,{4} );", nombre, direccion, celular, cant, total);
                            Utilidades.Ejecutar(cmd);
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message);
                        }

                        Modo = 0;
                        cant = Convert.ToInt32(artPedido);
                        total = Convert.ToDecimal(TotalPedido);

                        try
                        {
                            string cmd = string.Format("insert into Ventas (tipo_venta,cantidad,fecha,hora,total) values ({0},{1},GETDATE(), CURRENT_TIMESTAMP,{2} );", tipoVenta, cant, total);
                            Utilidades.Ejecutar(cmd);
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message);
                        }


                        pnlCobrarPe.Hide();
                        btn_CobrarPedido.Enabled = true;
                        activarProductos();
                        btnEliminarPediddo.Enabled = true;


                        DGV_V_P.Rows.Clear();
                        artPedido = 0;
                        TotalPedido = 0;
                        lblArtPedido.Text = "0";
                        lblTotalPedido.Text = "0";

                        richTextBox1.Text = "";
                        richTextBox2.Text = "";
                        richTextBox3.Text = "";
                        contF_P = 0;
                    }
                }
                else
                {
                    MessageBox.Show("No hay articulos por cobrar");
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            pnlCobrarPe.Hide();
            btn_CobrarPedido.Enabled = true;
            activarProductos();
            btnEliminarPediddo.Enabled = true;
            activarProductos();
            btn_CobrarPedido.Enabled = true;

            activarProductos();
            button24.Enabled = true;

            richTextBox1.Text = "";
            richTextBox2.Text = "";
            richTextBox3.Text = "";
        }

        private void richTextBox3_KeyPress(object sender, KeyPressEventArgs e)
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
            if (char.IsNumber(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == (int)Keys.Back)
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
            if (char.IsNumber(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == (int)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtP_stock_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void txtP_Precio_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
            if (textBox4.Text != "")
            {
                pago = Convert.ToDecimal(textBox4.Text);
                cambio = pago - TotalPedido;
                lblCambioP.Text = "$ " + cambio.ToString();
            }
            else
            {
                //MessageBox.Show("");
            }
        }

        private void btnRompope_Click(object sender, EventArgs e)
        {
                int p = 10;
            if (tipoVenta == 1)
            {
                agregarPLL(p);
            }
            else if (tipoVenta == 2)
            {
                if (MesaSeleccionada == 0)
                {
                    agregarMesaA(p);
                }
                else if (MesaSeleccionada == 1)
                {
                    agregarMesaB(p);
                }
                else if (MesaSeleccionada == 2)
                {
                    agregarMesaC(p);
                }
            }
            else if (tipoVenta == 3)
            {
                agregarPP(p);
            }
        }

        private void btnCapuchino_Click(object sender, EventArgs e)
        {
                int p = 11;
            if (tipoVenta == 1)
            {
                agregarPLL(p);
            }
            else if (tipoVenta == 2)
            {
                if (MesaSeleccionada == 0)
                {
                    agregarMesaA(p);
                }
                else if (MesaSeleccionada == 1)
                {
                    agregarMesaB(p);
                }
                else if (MesaSeleccionada == 2)
                {
                    agregarMesaC(p);
                }
            }
            else if (tipoVenta == 3)
            {

                agregarPP(p);
            }
        }

        private void txtPago_TextChanged(object sender, EventArgs e)
        {
            pago = 0;
            if (tipoVenta == 1)
            {
                if (txtPago.Text != "")
                {

                    pago = Convert.ToDecimal(txtPago.Text);
                    cambio = pago - totalLlevar;
                    lblCambio.Text = "$ " + cambio.ToString();
                }
                else
                {

                }
            }else if(tipoVenta == 2)
            {
                if (MesaSeleccionada == 0)
                {
                    if (txtPago.Text != "")
                    {
                        pago = Convert.ToDecimal(txtPago.Text);
                        cambio = pago - TotalMesaA;
                        lblCambio.Text = "$ " + cambio.ToString();

                    }
                    else
                    {

                    }
                }
                else if (MesaSeleccionada == 1)
                {
                    if (txtPago.Text != "")
                    {
                        pago = Convert.ToDecimal(txtPago.Text);
                         cambio = pago - TotalMesaB;
                        lblCambio.Text = "$ " + cambio.ToString();
                    }
                    else
                    {

                    }
                }
                else if (MesaSeleccionada == 2)
                {
                    if (txtPago.Text != "")
                    {
                        pago = Convert.ToDecimal(txtPago.Text);
                        cambio = pago - TotalMesaC;
                        lblCambio.Text = "$ " + cambio.ToString();
                    }
                    else
                    {

                    }
                }
            }

            else
            {
                //MessageBox.Show("");
            }
        }

        private void btnChocorrol_Click(object sender, EventArgs e)
        {
                int p = 12;
            if (tipoVenta == 1)
            {
                agregarPLL(p);
            }
            else if (tipoVenta == 2)
            {
                if (MesaSeleccionada == 0)
                {
                    agregarMesaA(p);
                }
                else if (MesaSeleccionada == 1)
                {
                    agregarMesaB(p);
                }
                else if (MesaSeleccionada == 2)
                {
                    agregarMesaC(p);
                }
            }
            else if (tipoVenta == 3)
            {
                agregarPP(p);
            }
        }

        private void btnChampurrado_Click(object sender, EventArgs e)
        {
                int p = 13;
            if (tipoVenta == 1)
            {
                agregarPLL(p);
            }
            else if (tipoVenta == 2)
            {
                if (MesaSeleccionada == 0)
                {
                    agregarMesaA(p);
                }
                else if (MesaSeleccionada == 1)
                {
                    agregarMesaB(p);
                }
                else if (MesaSeleccionada == 2)
                {
                    agregarMesaC(p);
                }
            }
            else if (tipoVenta == 3)
            {
                agregarPP(p);
            }
        }

        private void btnRefresco_Click(object sender, EventArgs e)
        {
                int p = 14;
            if (tipoVenta == 1)
            {
                agregarPLL(p);
            }
            else if (tipoVenta == 2)
            {
                if (MesaSeleccionada == 0)
                {
                    agregarMesaA(p);
                }
                else if (MesaSeleccionada == 1)
                {
                    agregarMesaB(p);
                }
                else if (MesaSeleccionada == 2)
                {
                    agregarMesaC(p);
                }
            }
            else if (tipoVenta == 3)
            {
                agregarPP(p);
            }
        }

        #endregion

        private void btnProductos_Click(object sender, EventArgs e)
        {
            panelReportes.Hide();
            panelInventarios.Hide();
            panelProductos.Show();
            panelVentas.Hide();
        }

        private void button23_Click(object sender, EventArgs e)//Borrar articulo PARA LLEVAR 
        {
            //Boton para borrar 
            if (contF_LL >0)
            {
                totalLlevar = totalLlevar - (Convert.ToDecimal(DGV_V_L.Rows[DGV_V_L.CurrentRow.Index].Cells[5].Value));
                artLlevar = artLlevar - (Convert.ToInt32(DGV_V_L.Rows[DGV_V_L.CurrentRow.Index].Cells[3].Value));
                lblArtLlevar.Text = artLlevar.ToString();
                lblTotalLlevar.Text = "$ " + totalLlevar.ToString();
                DGV_V_L.Rows.RemoveAt(DGV_V_L.CurrentRow.Index);
                contF_LL--;

                
            }
            else
            {
                MessageBox.Show("No hay articulos por eliminar!");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDT.Text = DateTime.Now.ToString();



            if (cantidadArtCom != 0)
            {
                DGV_V_L.Rows.Add(0000, descripcionArtCom, 0, cantidadArtCom, precioArtCom, importeArtCom);
               // MessageBox.Show(descripcionArtCom + cantidadArtCom + precioArtCom);
            }
            //pone la hora y fecha actual en el formato dado
        }

        private void btnEliminarPediddo_Click(object sender, EventArgs e) //bORRAR ARTICULO PEDIDO
        {
            //Boton para borrar 
            if (contF_P > 0)
            {
                TotalPedido = TotalPedido - (Convert.ToDecimal(DGV_V_P.Rows[DGV_V_P.CurrentRow.Index].Cells[4].Value));
                artPedido = artPedido - (Convert.ToInt32(DGV_V_P.Rows[DGV_V_P.CurrentRow.Index].Cells[2].Value));
                lblArtPedido.Text = artPedido.ToString();
                lblTotalPedido.Text = "$ " + TotalPedido.ToString();
                DGV_V_P.Rows.RemoveAt(DGV_V_P.CurrentRow.Index);
                contF_P--;
            }
            else
            {
                MessageBox.Show("No hay articulos por eliminar!");
            }
        }

        private void btnEliminarMesas_Click(object sender, EventArgs e) //Borrar articulo Mesas
        {
            if (MesaSeleccionada == 0) //Borrar MESA A
            {
                if (contF_MA > 0 )
                {
                    TotalMesaA = TotalMesaA - (Convert.ToDecimal(DGV_V_MA.Rows[DGV_V_MA.CurrentRow.Index].Cells[5].Value));
                    artMesaA = artMesaA - (Convert.ToInt32(DGV_V_MA.Rows[DGV_V_MA.CurrentRow.Index].Cells[3].Value));
                    lblArtMesa.Text = artMesaA.ToString();
                    lblTotalMesa.Text = "$ " + TotalMesaA.ToString();
                    DGV_V_MA.Rows.RemoveAt(DGV_V_MA.CurrentRow.Index);
                    contF_MA--;


                }
                else
                {
                    MessageBox.Show("No hay articulos por eliminar!");
                }
            }
            else if (MesaSeleccionada == 1)// BORRAR MESA B 
            {
                if (contF_MB > 0)
                {
                    TotalMesaB = TotalMesaB - (Convert.ToDecimal(DGV_V_MB.Rows[DGV_V_MB.CurrentRow.Index].Cells[5].Value));
                    artMesaB = artMesaB - (Convert.ToInt32(DGV_V_MB.Rows[DGV_V_MB.CurrentRow.Index].Cells[3].Value));
                    lblArtMesa.Text = artMesaB.ToString();
                    lblTotalMesa.Text = "$ " + TotalMesaB.ToString();
                    DGV_V_MB.Rows.RemoveAt(DGV_V_MB.CurrentRow.Index);
                    contF_MB--;
                }
                else
                {
                    MessageBox.Show("No hay articulos por eliminar!");
                }
            }
            else if (MesaSeleccionada == 2)
            {
                if (contF_MC >0 ) //mesa c 
                {
                    TotalMesaC = TotalMesaC - (Convert.ToDecimal(DGV_V_MC.Rows[DGV_V_MC.CurrentRow.Index].Cells[5].Value));
                    artMesaC = artMesaC - (Convert.ToInt32(DGV_V_MC.Rows[DGV_V_MC.CurrentRow.Index].Cells[3].Value));
                    lblArtMesa.Text = artMesaC.ToString();
                    lblTotalMesa.Text = "$ " + TotalMesaC.ToString();
                    DGV_V_MC.Rows.RemoveAt(DGV_V_MC.CurrentRow.Index);
                    contF_MC--;
                }
                else
                {
                    MessageBox.Show("No hay articulos por eliminar!");
                }
            }
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            MesaSeleccionada = TabControl.SelectedIndex;
            // MessageBox.Show(TabControl.SelectedIndex.ToString());
           // MessageBox.Show("Mesa Seleccionada= " + MesaSeleccionada);
           if (MesaSeleccionada == 0)
            {
                TotalMesaA = 0;
                foreach (DataGridViewRow fila in DGV_V_MA.Rows)
                {
                    TotalMesaA += Convert.ToDecimal(fila.Cells[5].Value);
                    artMesaA += Convert.ToInt32(fila.Cells[3].Value);
                }

                lblTotalMesa.Text = "$ " + TotalMesaA.ToString();
                lblArtMesa.Text = artMesaA.ToString();
            } else if (MesaSeleccionada == 1)
            {
                TotalMesaB = 0;
                foreach (DataGridViewRow fila in DGV_V_MB.Rows)
                {
                    TotalMesaB += Convert.ToDecimal(fila.Cells[5].Value);
                    artMesaB += Convert.ToInt32(fila.Cells[3].Value);
                }

                lblTotalMesa.Text = "$ " + TotalMesaB.ToString();
                lblArtMesa.Text = artMesaB.ToString();
            } else if (MesaSeleccionada == 2)
            {
                TotalMesaC = 0;
                foreach (DataGridViewRow fila in DGV_V_MC.Rows)
                {
                    TotalMesaC += Convert.ToDecimal(fila.Cells[5].Value);
                    artMesaC += Convert.ToInt32(fila.Cells[3].Value);
                }

                lblTotalMesa.Text = "$ " + TotalMesaC.ToString();
                lblArtMesa.Text = artMesaC.ToString();
            }
        }

        private void btnInventarios_Click(object sender, EventArgs e)
        {
            panelReportes.Hide();
            panelInventarios.Show();
            panelProductos.Hide();
            panelVentas.Hide();
            DGV_I_I.DataSource = llenadoDGV("productos").Tables[0];

        }

        private void btnReportes_Click_1(object sender, EventArgs e)
        {
            panelReportes.Show();
            panelInventarios.Hide();
            panelProductos.Hide();
            panelVentas.Hide();
            DGVSesiones.DataSource = llenadoDGV("sesiones").Tables[0];
            DGVSesiones.DataSource = llenadoDGV("usuarios").Tables[0];
            DGV_R_R.DataSource = llenadoDGV("ventas").Tables[0];
            DGV_Pedidos.DataSource = llenadoDGV("pedidos").Tables[0];


            panelSesiones.Show();


        }

        void desactivarProdutos()
        {
            btnAgregarArtComun.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            btnAsadoRojo.Enabled = false;
            btnRajas.Enabled = false;
            btnSalsaVerde.Enabled = false;
            btnChicharron.Enabled = false;
            btnAsadoVerde.Enabled = false;
            btnPina.Enabled = false;
            btnFresa.Enabled = false;
            btnCajeta.Enabled = false;
            btnZarzamora.Enabled = false;
            btnRompope.Enabled = false;
            btnCapuchino.Enabled = false;
            btnChocorrol.Enabled = false;
            btnRefresco.Enabled = false;
            btnChampurrado.Enabled = false;
        }

        void activarProductos()
        {
            btnAgregarArtComun.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            btnAsadoRojo.Enabled = true;
            btnRajas.Enabled = true;
            btnSalsaVerde.Enabled = true;
            btnChicharron.Enabled = true;
            btnAsadoVerde.Enabled = true;
            btnPina.Enabled = true;
            btnFresa.Enabled = true;
            btnCajeta.Enabled = true;
            btnZarzamora.Enabled = true;
            btnRompope.Enabled = true;
            btnCapuchino.Enabled = true;
            btnChocorrol.Enabled = true;
            btnRefresco.Enabled = true;
            btnChampurrado.Enabled = true;
        }



    }

}
