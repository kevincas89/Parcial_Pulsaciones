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

        public ConsultaResponse Consultar()
        {
            try
            {
               //retorno una lista de tipo persona 
               return new ConsultaResponse( registroPersona.Consultar());
            }
            catch (Exception exception)
            {
                //retorno un string con un mensaje
                return new ConsultaResponse("Ocurrieron los siguientes errores: " + exception.Message);
            }
        }
    }

    public class ConsultaResponse
    {
        public List<Persona> personas { get; set; }

        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public ConsultaResponse(List<Persona> personas)
        {
            personas = personas;
            Error = false;
        }

        public ConsultaResponse(String mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
}
