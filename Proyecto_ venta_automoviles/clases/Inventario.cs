using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCV.clases
{
    public class Inventario
    {
        private List<Vehiculo> listaVehiculos = new List<Vehiculo>();

        public List<Vehiculo> Lista()
        {
            return listaVehiculos;
        }

        public bool ExisteVehiculo(Vehiculo vehiculo)
        {

            return listaVehiculos.Contains(vehiculo);
        }

        public void AgregarVehiculo(Vehiculo vehiculo)
        {
            listaVehiculos.Add(vehiculo);
        }

        public Vehiculo ObtenerVehiculo(int index)          
        {
            if (index >= 0 && index < listaVehiculos.Count)
            {
                return listaVehiculos[index];
            }
            throw new IndexOutOfRangeException("Índice fuera de rango");
        }

        public void EliminarVehiculo(Vehiculo vehiculo)
        {
            listaVehiculos.Remove(vehiculo);
        }

        public void MostrarInventario()
        {
            foreach (var vehiculo in listaVehiculos)
            {
                vehiculo.MostrarDetalles();
            }
        }


    }
}