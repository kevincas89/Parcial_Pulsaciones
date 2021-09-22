using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentación
{
    class Program
    {
        static void Main(string[] args)
        {
            string identificacion, nombre, sexo;
            int edad;
            decimal pulsacion;

            Console.WriteLine("Digite la Identificacion: ");
            identificacion = Console.ReadLine();

            Console.WriteLine("Digite El Nombre: ");
            nombre = Console.ReadLine();

            Console.WriteLine("Digite El sexi (M/F): ");
            sexo = Console.ReadLine();
           
            Console.WriteLine("Digite la Edad: ");
            edad = int.Parse(Console.ReadLine());

            if (sexo.ToUpper().Equals("M"))
            {
                pulsacion = (210 - edad) / 10;

            }else if (sexo.ToUpper().Equals("F"))
            {
                pulsacion = (220 - edad) / 10;
            }
            else
            {
                pulsacion = 0;
            }
            Console.WriteLine($"Su pulsacion es {pulsacion}");
            Console.ReadKey();

        }
    }
}
