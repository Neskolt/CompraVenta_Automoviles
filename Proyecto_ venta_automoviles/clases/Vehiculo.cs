using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DemoCV.clases
{
    public class Vehiculo
    {
        public string Idv { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Año { get; set; }
        public decimal Precio { get; set; }
        public int Kilometraje { get; set; }

        public Vehiculo()
        {
            Guid guid = Guid.NewGuid();
            Idv = guid.ToString();
        }

        public void MostrarDetalles()
        {
            Console.WriteLine($"Marca: {Marca}, Modelo: {Modelo}, Año: {Año},Precio:{Precio},Km:{Kilometraje}");

        }
        public string[] itemView()
        {
            string[] data = {
                Idv,
                Marca,
                Modelo,
                Año.ToString(),  // Mostrar el año como string
                Precio.ToString(),  // Convertir el precio a string
                Kilometraje.ToString()  // Convertir el kilometraje a string
            };
            return data;
        }

        public override string ToString()
        {
            return $"Marca: {Marca}, Modelo: {Modelo}, Año: {Año},Precio:{Precio},Km:{Kilometraje}";
        }

    }
}
