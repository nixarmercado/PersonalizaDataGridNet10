using CapaNegocio;

namespace AppDataGridPersonalizada
{
    public partial class Form1 : Form
    {
        //Declaracion de objeto referente a la clase de la CapaNegocio
        private CN_Productos objetoCN = new CN_Productos();
        //Variable privada de tipo string para obtener el Id desde la fila seleccionada de la DataGrid
        private string idProducto = null;

        //
        private bool Editar = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Inicio del metodo para cargar los datos desde la ejecucion
            CargarDatos();
        }

        private void CargarDatos()
        {
            //Al definir de forma interna este objeto, me permite refrescar la Grid sin repeticion de datos
            CN_Productos objeto = new CN_Productos();
            //Cargar el origen de los datos hacia la Grid
            dgvProductos.DataSource = objeto.MostrarProd();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                //Se evitar errores de quiebre
                try
                {
                    //En via los datos al metodo de la CapaNegocio de la clase CN_Productos por medio del objetoCN
                    objetoCN.InsertarProductos(txtNombre.Text, txtDescrip.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text);
                    MessageBox.Show("Se guardaron los datos");
                    CargarDatos();
                    Editar = false;
                    LimpiarCajas();
                }
                //Si existe un error informa el caso
                catch (Exception ex)
                {
                    //En caso de ocurrir un problema
                    MessageBox.Show("No se gurdaron los datos a causa de: " + ex);
                }
            }
            if (Editar == true)
            {
                try
                {
                    objetoCN.EditarProductos(txtNombre.Text, txtDescrip.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text, idProducto);
                    MessageBox.Show("Se Editaron los datos correctamente.");
                    CargarDatos();
                    LimpiarCajas();

                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se Editaron los datos por causa de: " + ex);
                }
            }


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                Editar = true;
                txtNombre.Text = dgvProductos.CurrentRow.Cells["Nombre"].Value.ToString();
                txtDescrip.Text = dgvProductos.CurrentRow.Cells["Descripcion"].Value.ToString();
                txtMarca.Text = dgvProductos.CurrentRow.Cells["Marca"].Value.ToString();
                txtPrecio.Text = dgvProductos.CurrentRow.Cells["Precio"].Value.ToString();
                txtStock.Text = dgvProductos.CurrentRow.Cells["Stock"].Value.ToString();
                idProducto = dgvProductos.CurrentRow.Cells["Id"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione una Fila por favor");
            }
        }

        private void LimpiarCajas()
        {
            txtNombre.Text = "";
            txtDescrip.Text = "";
            txtMarca.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                idProducto = dgvProductos.CurrentRow.Cells["Id"].Value.ToString();
                objetoCN.EliminarProducto(idProducto);
                MessageBox.Show("Eliminado Correctamente");
                CargarDatos();
            }
            else
                MessageBox.Show("Seleccione una fila por favor");
        }
    }
}
