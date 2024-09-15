using DemoCV.clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Ventas : Form
    {
        string IdGlobalvn = "";

        public Ventas()
        {
            InitializeComponent();
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            // Limpiar el ListView para evitar acumulación de ventas anteriores
            listView1.Items.Clear();

            // Agregar clientes precargados si no están presentes
            if (GlobalVar.clientes.Count == 0)
            {
                GlobalVar.clientes.AddRange(new List<Cliente>
                {
                    new Cliente { Nombre = "Juan", Apellidos = "Pérez", DineroDisponible = 1000 },
                    new Cliente { Nombre = "María", Apellidos = "González", DineroDisponible = 2000 },
                    new Cliente { Nombre = "Carlos", Apellidos = "Ramírez", DineroDisponible = 1500 },
                    new Cliente { Nombre = "Ana", Apellidos = "Fernández", DineroDisponible = 3000 },
                    new Cliente { Nombre = "Luis", Apellidos = "Martínez", DineroDisponible = 2500 }
                });
            }
            
            // Cargar los clientes y vehículos en los ComboBox
            cargaClientes();
            cargaVehiculos();

            // Configurar columnas del ListView
            listView1.Columns.Add("Cliente", 100);
            listView1.Columns.Add("Vehículo", 100);
            listView1.Columns.Add("Precio", 100);
            listView1.Columns.Add("Fecha", 150);
            listView1.Columns.Add("ID", 0); // Columna invisible

            listView1.View = View.Details;
            listView1.FullRowSelect = true;
        }



        void cargaClientes()
        {
            cb_clientes.Items.Clear();
            cb_clientes.Items.AddRange(GlobalVar.clientes.ToArray());
        }

        void cargaVehiculos()
        {
            cb_vehiculo.Items.Clear();
            cb_vehiculo.Items.AddRange(GlobalVar.Inventario.Lista().ToArray());
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                // Obtener el item seleccionado
                ListViewItem itemSeleccionado = listView1.SelectedItems[0];

                // Eliminar el item del ListView
                listView1.Items.Remove(itemSeleccionado);
                MessageBox.Show("Venta eliminada.");
            }
            else
            {
                MessageBox.Show("Seleccione una venta para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cb_vehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Vehiculo vehiculoSeleccionado = cb_vehiculo.SelectedItem as Vehiculo;
            if (vehiculoSeleccionado != null)
            {
                tx_precio.Text = vehiculoSeleccionado.Precio.ToString("C");
            }
            else
            {
                tx_precio.Text = string.Empty;
            }
        }

        private void bt_guardar_Click(object sender, EventArgs e)
        {
            Cliente clienteSeleccionado = cb_clientes.SelectedItem as Cliente;
            Vehiculo vehiculoSeleccionado = cb_vehiculo.SelectedItem as Vehiculo;

            // Validación de cliente y vehículo antes de registrar la venta
            if (clienteSeleccionado == null || vehiculoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un cliente y un vehículo antes de registrar la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Salir del método si uno de los valores es nulo
            }

            if (clienteSeleccionado.DineroDisponible < vehiculoSeleccionado.Precio)
            {
                MessageBox.Show("El cliente no tiene suficiente dinero para comprar el vehículo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Salir del método si el cliente no tiene suficiente dinero
            }

            // Llamar al método RegistrarVenta solo si los valores son válidos
            Concesionario.Instancia.RegistrarVenta(vehiculoSeleccionado, clienteSeleccionado);

            // Código para modificar o agregar un nuevo item al ListView (sin cambios)
            if (!string.IsNullOrEmpty(IdGlobalvn))
            {
                foreach (ListViewItem item in listView1.Items)
                {
                    if (item.SubItems[4].Text == IdGlobalvn)
                    {
                        item.SubItems[0].Text = clienteSeleccionado.Nombre;
                        item.SubItems[1].Text = vehiculoSeleccionado.Modelo;
                        if (decimal.TryParse(tx_precio.Text, out decimal precioModificado))
                        {
                            item.SubItems[2].Text = precioModificado.ToString("C");
                        }
                        else
                        {
                            MessageBox.Show("El formato del precio no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        item.SubItems[3].Text = DateTime.Now.ToString();
                        MessageBox.Show("Modificación guardada correctamente.");
                        IdGlobalvn = "";
                        break;
                    }
                }
            }
            else
            {
                string idVenta = Guid.NewGuid().ToString();
                ListViewItem item = new ListViewItem(clienteSeleccionado.Nombre);
                item.SubItems.Add(vehiculoSeleccionado.Modelo);
                item.SubItems.Add(vehiculoSeleccionado.Precio.ToString("C"));
                item.SubItems.Add(DateTime.Now.ToString());
                item.SubItems.Add(idVenta);

                listView1.Items.Add(item);
                clienteSeleccionado.DineroDisponible -= vehiculoSeleccionado.Precio;
                MessageBox.Show("Venta registrada correctamente.");
            }

            cb_clientes.SelectedIndex = -1;
            cb_vehiculo.SelectedIndex = -1;
            tx_precio.Clear();
        }

        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void modificarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            tx_precio.ReadOnly = false;
            if (listView1.SelectedItems.Count > 0)
            {
                // Obtener el item seleccionado
                ListViewItem itemSeleccionado = listView1.SelectedItems[0];

                // Guardar el ID del elemento para modificarlo más tarde
                IdGlobalvn = itemSeleccionado.SubItems[4].Text; // Usamos el ID único en lugar de la fecha

                // Rellenar los campos con los valores del elemento seleccionado
                cb_clientes.SelectedItem = GlobalVar.clientes.FirstOrDefault(c => c.Nombre == itemSeleccionado.SubItems[0].Text);
                cb_vehiculo.SelectedItem = GlobalVar.Inventario.Lista().FirstOrDefault(v => v.Modelo == itemSeleccionado.SubItems[1].Text);

                tx_precio.Text = itemSeleccionado.SubItems[2].Text.Replace("$", ""); // Precio
            }
            else
            {
                MessageBox.Show("Seleccione una venta para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
