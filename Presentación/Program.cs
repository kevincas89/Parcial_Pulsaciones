using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persona;

namespace Presentación
{
    class Program
    {
        static void Main(string[] args)
        {
            string Identificacion, Nombre, Sexo;
            int Edad;
            decimal Pulsacion;

            Console.WriteLine("Digite la Identificacion: ");
            Identificacion = Console.ReadLine();

            Console.WriteLine("Digite El Nombre: ");
            Nombre = Console.ReadLine();

            Console.WriteLine("Digite El sexi (M/F): ");
            Sexo = Console.ReadLine();
           
            Console.WriteLine("Digite la Edad: ");
            Edad = int.Parse(Console.ReadLine());

            Persona persona = new Persona(Identificacion,Nombre,Edad,Sexo);
            persona.CalcularPulsacion();
            Console.WriteLine($"Su pulsacion es {persona.Pulsacion}");
            Console.ReadKey();

        }
    }
}
