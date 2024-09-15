namespace DemoCV.clases
{
    public class Concesionario
    {
        public string Nombre { get; set; }
        public Inventario Inventario { get; set; } = new Inventario(); // Inicializar Inventario
        public List<Venta> VentasRealizadas = new List<Venta>();
        public static Concesionario Instancia { get; set; } = new Concesionario();


        public Concesionario()
        {
            // Si es necesario, se puede inicializar aquí también
            Inventario = new Inventario(); // Asegurar que Inventario no es null
        }

        public void RegistrarVenta(Vehiculo vehiculo, Cliente cliente)
        {
            // Validar que el vehículo y el cliente no sean nulos
            if (vehiculo == null || cliente == null)
            {
                MessageBox.Show("Seleccione un cliente y un vehículo antes de registrar la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }                
            else
            {
                Venta nuevaVenta = new Venta()
                {
                    VehiculoVendido = vehiculo,
                    Cliente = cliente,
                    PrecioVenta = vehiculo.Precio,
                    FechaVenta = DateTime.Now
                };

                VentasRealizadas.Add(nuevaVenta);
                cliente.ComprarVehiculo(vehiculo, Inventario);
            }
        }

        public void MostrarHistorialVentas()
        {
            foreach (var venta in VentasRealizadas)
            {
                venta.MostrarDetalleVenta();
            }
        }
    }
}