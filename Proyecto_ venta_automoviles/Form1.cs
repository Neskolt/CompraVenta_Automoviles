using DemoCV.clases;
using System.Diagnostics;
using System.Security.Principal;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        string IdGlobal = "";
        public Form1()
        {
            InitializeComponent();
        }

        void ListarClientes()
        {
            listView1.Items.Clear();
            foreach (Cliente cliente in GlobalVar.clientes)
            {
                listView1.Items.Add(new ListViewItem(new[] { cliente.Idc, cliente.Nombre, cliente.Apellidos, cliente.DineroDisponible.ToString("C") }));
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                // Obtener el elemento seleccionado
                ListViewItem itemSeleccionado = listView1.SelectedItems[0];

                // Actualizar los valores en el ListView
                itemSeleccionado.SubItems[0].Text = tx_nombre.Text;
                itemSeleccionado.SubItems[1].Text = tx_apellido.Text;
                itemSeleccionado.SubItems[2].Text = decimal.Parse(tx_dinero.Text).ToString("C"); // Formato de moneda

                // También actualizar en la lista de clientes
                Cliente cliente = GlobalVar.clientes[listView1.SelectedIndices[0]];
                cliente.Nombre = tx_nombre.Text;
                cliente.Apellidos = tx_apellido.Text;
                cliente.DineroDisponible = decimal.Parse(tx_dinero.Text);

                MessageBox.Show("Modificación guardada correctamente.");
            }
            else
            {
                if (String.IsNullOrEmpty(tx_nombre.Text))
                {
                    MessageBox.Show("Debes ingresar un nombre");
                    tx_nombre.Focus();
                    return;
                }
                if (String.IsNullOrEmpty(tx_apellido.Text))
                {
                    MessageBox.Show("Debes ingresar un apellido");
                    tx_apellido.Focus();
                    return;
                }

                if (String.IsNullOrEmpty(tx_dinero.Text))
                {
                    MessageBox.Show("Debes ingresar un monto de dinero disponible");
                    tx_dinero.Focus();
                    return;
                }

                if (!decimal.TryParse(tx_dinero.Text, out decimal dineroDisponible))
                {
                    MessageBox.Show("Ingresa un monto válido de dinero");
                    tx_dinero.Focus();
                    return;
                }

                Cliente cliente = new Cliente()
                {
                    Nombre = tx_nombre.Text,
                    Apellidos = tx_apellido.Text,
                    DineroDisponible = dineroDisponible
                };

                if (String.IsNullOrEmpty(IdGlobal))
                {
                    GlobalVar.clientes.Add(cliente);
                    MessageBox.Show("Cliente Almacenado");

                }
                else
                {
                    Cliente cliente_modificar = GlobalVar.clientes.Where(x => x.Idc == IdGlobal).FirstOrDefault()!;
                    cliente_modificar.Nombre = tx_nombre.Text;
                    cliente_modificar.Apellidos = tx_apellido.Text;
                    cliente_modificar.DineroDisponible = Convert.ToDecimal(tx_dinero.Text);
                    IdGlobal = "";
                }

                ListarClientes();
                tx_nombre.Clear();
                tx_apellido.Clear();
                tx_dinero.Clear();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.GridLines = true;            
            listView1.Columns.Add("Idc", 0);
            listView1.Columns.Add("Nombre", 100);
            listView1.Columns.Add("Apellido", 100);
            listView1.Columns.Add("Dinero", 100);
            ListarClientes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String id = listView1.SelectedItems[0].Text;
            Cliente cliente_eliminar = GlobalVar.clientes.Where(x => x.Idc == id).FirstOrDefault()!;
            GlobalVar.clientes.Remove(cliente_eliminar);
            ListarClientes();
            MessageBox.Show("Cliente eliminado");
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String id = listView1.SelectedItems[0].Text;
            IdGlobal = id;
            Cliente cliente_modificar = GlobalVar.clientes.Where(x => x.Idc == id).FirstOrDefault()!;
            tx_nombre.Text = cliente_modificar.Nombre;
            tx_apellido.Text = cliente_modificar.Apellidos;
            tx_dinero.Text = Convert.ToString(cliente_modificar.DineroDisponible);

        }
    }
}