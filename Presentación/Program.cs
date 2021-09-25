using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Logica;

namespace Presentación
{
    class Program
    {
       static PersonaService servicio = new PersonaService();

        static void Main(string[] args)
        {

            Menu();

        }

        static void Menu()
        {

            int opc;


            do
            {

                Console.WriteLine("\nMenu DE Opciones\n");
                Console.WriteLine("1... Reguistrar Persona");
                Console.WriteLine("2... Consultar Persona");
                Console.WriteLine("3... Modificar Persona");
                Console.WriteLine("4... Eliminar Persona");
                Console.WriteLine("5... Salir\n");
                Console.Write("Ingrese opcion ->");
                opc = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");

                switch (opc)
                {
                    case 1:
                        Registrar();
                        break;
                    case 2:
                        Consultar();
                        break;
                    case 3:
                        Modificar();
                        break;
                    case 4:
                        Eliminar();
                        break;
                    case 5:
                        Console.WriteLine("Parcial hecho por Kevin Castillo Aroca y Juan Pablo Mendoza Amaya");
                        Console.ReadKey();
                        break;
                    default: Console.WriteLine("Valor fuera de rango, las opciones van del 1 al 5");
                        Console.ReadKey();
                        break;
                    

                }

                
                Console.Clear();

            } while (opc != 5);


        }

        private static void Eliminar()
        {

            Console.Write("Ingrese Identificación: ");
            Console.WriteLine(servicio.Eliminar(Console.ReadLine()));
            Console.ReadKey();

        }

        private static void Modificar()
        {
            string Mensaje;
            Persona persona = new Persona();

            Console.Write("Ingrese la Identificacion a Modificar: ");
            persona.Identificacion = Console.ReadLine();

            Console.Write("Digite El Nombre: ");
            persona.Nombre = Console.ReadLine();

            Console.Write("Digite El sexo (M/F): ");
            persona.Sexo = Console.ReadLine();

            Console.Write("Digite la Edad: ");
            persona.Edad = int.Parse(Console.ReadLine());

            persona.CalcularPulsaciones();
            Mensaje = servicio.Modificar(persona, persona.Identificacion);
            Console.Write(Mensaje);
            Console.ReadKey();
        }

        private static void Consultar()
        {
            ConsultaResponse response = servicio.Consultar();

            if (!response.Error)
            {
                foreach (var item in response.Personas)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            else
            {
                Console.WriteLine(response.Mensaje);
            }

            Console.ReadKey();
        }

        private static void Registrar()
        {
            Persona persona = new Persona();

            string Mensaje;

                       
            Console.Write("Digite la Identificacion: ");
            persona.Identificacion= Console.ReadLine();

            Console.Write("Digite El Nombre: ");
            persona.Nombre = Console.ReadLine();

            Console.Write("Digite El sexo (M/F): ");
            persona.Sexo = Console.ReadLine();

            Console.Write("Digite la Edad: ");
            persona.Edad = int.Parse(Console.ReadLine());

            persona.CalcularPulsaciones();
            Mensaje = servicio.Guardar(persona);

            Console.WriteLine(Mensaje);
            Console.ReadKey();

        }
    }
}
