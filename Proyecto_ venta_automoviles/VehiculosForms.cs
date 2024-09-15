using DemoCV.clases;
using System;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class VehiculosForms : Form
    {
        string IdGlobalv = "";

        public VehiculosForms()
        {
            InitializeComponent();
        }

        void cargaVehiculos()
        {
            listView1.Items.Clear();
            foreach (Vehiculo vehiculo in GlobalVar.Inventario.Lista())
            {
                ListViewItem item = new ListViewItem(vehiculo.Idv);
                item.SubItems.Add(vehiculo.Marca);
                item.SubItems.Add(vehiculo.Modelo);
                item.SubItems.Add(vehiculo.Año.ToString());
                item.SubItems.Add(vehiculo.Kilometraje.ToString()); // Agregar el kilometraje
                item.SubItems.Add(vehiculo.Precio.ToString("C")); // Formato de moneda

                listView1.Items.Add(item);
            }
        }

        private void VehiculosForms_Load(object sender, EventArgs e)
        {
            cargaVehiculos();
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.Columns.Add("Id");
            listView1.Columns.Add("Marca");
            listView1.Columns.Add("Modelo");
            listView1.Columns.Add("Año");
            listView1.Columns.Add("Kilometraje");
            listView1.Columns.Add("Precio");

            foreach (ColumnHeader column in listView1.Columns)
            {
                column.Width = 100;
            }
        }

        private void bt_guardar_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                // Obtener el vehículo seleccionado
                ListViewItem itemSeleccionado = listView1.SelectedItems[0];

                // Actualizar los valores en el ListView
                itemSeleccionado.SubItems[1].Text = tx_marca.Text;
                itemSeleccionado.SubItems[2].Text = tx_modelo.Text;
                itemSeleccionado.SubItems[3].Text = tx_año.Text;
                itemSeleccionado.SubItems[4].Text = tx_km.Text;  // Actualizar el kilometraje
                itemSeleccionado.SubItems[5].Text = decimal.Parse(tx_precio.Text).ToString("C"); // Formato Moneda

                // Actualizar en la lista global de vehículos
                Vehiculo vehiculo = GlobalVar.Inventario.ObtenerVehiculo(listView1.SelectedIndices[0]);
                vehiculo.Marca = tx_marca.Text;
                vehiculo.Modelo = tx_modelo.Text;
                vehiculo.Año = int.Parse(tx_año.Text);
                vehiculo.Kilometraje = int.Parse(tx_km.Text);  // Actualizar el kilometraje
                vehiculo.Precio = decimal.Parse(tx_precio.Text);

                MessageBox.Show("Modificación guardada correctamente.");
            }
            else
            {
                if (String.IsNullOrEmpty(tx_marca.Text))
                {
                    MessageBox.Show("Debes ingresar una marca");
                    tx_marca.Focus();
                    return;
                }
                if (String.IsNullOrEmpty(tx_modelo.Text))
                {
                    MessageBox.Show("Debes ingresar un modelo");
                    tx_modelo.Focus();
                    return;
                }

                if (String.IsNullOrEmpty(tx_año.Text))
                {
                    MessageBox.Show("Debes ingresar un año válido");
                    tx_año.Focus();
                    return;
                }

                if (String.IsNullOrEmpty(tx_km.Text))
                {
                    MessageBox.Show("Debes ingresar un kilometraje");
                    tx_km.Focus();
                    return;
                }

                if (!decimal.TryParse(tx_precio.Text, out decimal precio))
                {
                    MessageBox.Show("Ingresa un monto válido de dinero");
                    tx_precio.Focus();
                    return;
                }

                Vehiculo nuevoVehiculo = new Vehiculo
                {
                    Marca = tx_marca.Text,
                    Modelo = tx_modelo.Text,
                    Año = int.Parse(tx_año.Text),
                    Kilometraje = int.Parse(tx_km.Text),
                    Precio = decimal.Parse(tx_precio.Text),
                };

                if (String.IsNullOrEmpty(IdGlobalv))
                {
                    GlobalVar.Inventario.AgregarVehiculo(nuevoVehiculo);
                    MessageBox.Show("Vehículo Almacenado");
                }
                else
                {
                    Vehiculo vehiculo_modificar = GlobalVar.Inventario.Lista().Where(x => x.Idv == IdGlobalv).FirstOrDefault();
                    if (vehiculo_modificar != null)
                    {
                        vehiculo_modificar.Marca = tx_marca.Text;
                        vehiculo_modificar.Modelo = tx_modelo.Text;
                        vehiculo_modificar.Año = int.Parse(tx_año.Text);
                        vehiculo_modificar.Kilometraje = int.Parse(tx_km.Text);
                        vehiculo_modificar.Precio = decimal.Parse(tx_precio.Text);
                        IdGlobalv = "";
                    }
                }

                cargaVehiculos();
                tx_marca.Clear();
                tx_modelo.Clear();
                tx_año.Clear();
                tx_km.Clear();
                tx_precio.Clear();
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                String idv = listView1.SelectedItems[0].SubItems[0].Text;
                Vehiculo vehiculo_eliminar = GlobalVar.Inventario.Lista().Where(x => x.Idv == idv).FirstOrDefault();
                if (vehiculo_eliminar != null)
                {
                    GlobalVar.Inventario.EliminarVehiculo(vehiculo_eliminar);
                    cargaVehiculos();
                    MessageBox.Show("Vehículo eliminado");
                }   
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                String idv = listView1.SelectedItems[0].SubItems[0].Text;
                IdGlobalv = idv;
                Vehiculo vehiculo_modificar = GlobalVar.Inventario.Lista().Where(x => x.Idv == idv).FirstOrDefault();
                if (vehiculo_modificar != null)
                {
                    tx_marca.Text = vehiculo_modificar.Marca;
                    tx_modelo.Text = vehiculo_modificar.Modelo;
                    tx_año.Text = vehiculo_modificar.Año.ToString();
                    tx_km.Text = vehiculo_modificar.Kilometraje.ToString();
                    tx_precio.Text = vehiculo_modificar.Precio.ToString("F"); // Mostrar solo el número sin formato de moneda
                }
            }
            else
            {
                MessageBox.Show("Seleccione un vehículo para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}