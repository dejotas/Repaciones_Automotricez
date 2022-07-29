namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        double precio = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //fechaa actual
            lblFecha.Text = DateTime.Today.Date.ToString("d");
            //Precio del producto en decimales
            lblPrecio.Text = (0).ToString("C");
        }

        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            string producto = cboProducto.Text;

            if (producto.Equals("Chevrolet")) precio = 1500;
            if (producto.Equals("Nissan")) precio = 2000;
            if (producto.Equals("Ford")) precio = 5000;

            lblPrecio.Text = precio.ToString("C");
        }
        private void btnSalir_Click(object sender, EventArgs e)
            {
            Close();        
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Validando
            if (cboProducto.SelectedIndex == -1)
                MessageBox.Show("Debe seleccionar un producto...!!!");
            else if (txtCantidad.Text == "")
                MessageBox.Show("Debe ingresar una cantidad..!!!");
            else if (cboTipo.SelectedIndex == -1) 
                MessageBox.Show("Debe seleccionar un tipo...!!!");
            else
            {
                //caotura de datos
                string producto = cboProducto.Text;
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                string tipo = cboTipo.Text;
                //procesar calculos
                double subtotal = cantidad * precio;

                double descuento = 0,recargo=0   ;
                if (tipo.Equals("Contado"))
                    descuento = 0.05 * subtotal;
                else
                    recargo = 0.1 * subtotal;
                double precioFinal = subtotal - descuento + recargo;

                //imprimir lo resultados
                ListViewItem fila = new ListViewItem(producto);                
                fila.SubItems.Add(cantidad.ToString());
                fila.SubItems.Add(precio.ToString());
                fila.SubItems.Add(tipo);
                fila.SubItems.Add(descuento.ToString());
                fila.SubItems.Add(recargo.ToString());
                fila.SubItems.Add(precioFinal.ToString());
                lvVenta.Items.Add(fila);
                btnCancelar_Click(sender, e);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cboProducto.Text = "(Seleccione producto)";
            cboProducto.Text = "(Seleccione tipo)";
            txtCantidad.Clear();
            lblPrecio.Text = (0).ToString("C");
            cboProducto.Focus();

        }
    }
}