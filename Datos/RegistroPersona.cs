using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;

namespace Datos
{
    class RegistroPersona
    {
        string ruta = "persona.txt";

        public void Guardar(Persona persona)
        {

            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{persona.Identificacion};{persona.Nombre};{persona.Sexo};{persona.Edad};{persona.Pulsacion}");
        }

        public List<Persona> Consultar()
        {
            List<Persona> personas = new List<Persona>();
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate);
            StreamReader lector = new StreamReader(file);

            string linea = "";

            while ((linea = lector.ReadLine()) != null)
            {

                string[] datosPersona = linea.Split(';');
                Persona persona = new Persona()
                {

                    Identificacion = datosPersona[0],
                    Nombre = datosPersona[1],
                    Sexo = datosPersona[2],
                    Edad = Int16.Parse(datosPersona[3]),
                    Pulsacion = Convert.ToDecimal(datosPersona[4])

                };
                personas.Add(persona);

            }
            lector.Close();
            file.Close();
            return personas;

        
        }

        public void Eliminar(string Identificacion)
        {

            List<Persona> personas = Consultar();
            FileStream file = new FileStream(ruta, FileMode.Create);
            file.Close();

            foreach (var item in personas)
            {

                if (!item.Identificacion.Equals(Identificacion))
                {

                    Guardar(item);

                }

            }



        }

        public void Modificar(Persona personaNuevo, string Identificacion)
        {



        }

    }
}
