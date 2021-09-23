using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;

namespace Presentación
{
    class Program
    {
        static void Main(string[] args)
        {
            string Identificacion, Nombre, Sexo;
            int Edad;
            

            Console.WriteLine("Digite la Identificacion: ");
            Identificacion = Console.ReadLine();

            Console.WriteLine("Digite El Nombre: ");
            Nombre = Console.ReadLine();

            Console.WriteLine("Digite El sexo (M/F): ");
            Sexo = Console.ReadLine();
           
            Console.WriteLine("Digite la Edad: ");
            Edad = int.Parse(Console.ReadLine());

            Persona persona = new Persona(Identificacion,Nombre,Edad,Sexo);
            persona.CalcularPulsaciones();
            Console.WriteLine($"Su pulsacion es {persona.Pulsacion}");
            Console.ReadKey();

        }
    }
}
