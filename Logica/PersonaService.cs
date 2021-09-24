using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidad;


namespace Logica
{
    public class PersonaService
    {
        RegistroPersona registroPersona;
        public PersonaService()
        {
            registroPersona = new RegistroPersona();
        }

        public string Guardar(Persona persona)
        {
            try
            {
                registroPersona.Guardar(persona);
                return "Datos guardados correctamente";
            }
            catch (Exception exception)
            {

                return "Ocurrieron los siguientes errores: " + exception.Message;
            }
        }
    }
}
