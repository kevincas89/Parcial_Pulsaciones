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
                if (registroPersona.BuscarPorIdentificacion(persona.Identificacion)==null)
                {
                    registroPersona.Guardar(persona);
                    return "Datos guardados correctamente";
                }
                return $"La persona con la identificacion {persona.Identificacion} ya se encuentra registrada.";
                
            }
            catch (Exception exception)
            {

                return "Ocurrieron los siguientes errores: " + exception.Message;
            }
        }

        public string Eliminar(string identificacion)
        {
            try
            {
                if (registroPersona.BuscarPorIdentificacion(identificacion)!=null)
                {
                    registroPersona.Eliminar(identificacion);
                    return $"Se elimino a la persona con la identificacion {identificacion}";
                }
                return $"No se encontro a la persona con identificacion{identificacion}";
            }
            catch (Exception exception)
            {

                return "Ocurrieron los siguientes errores: " + exception.Message;
            }
        }

        public string Modificar(Persona personaNueva, string identificacion)
        {
            try
            {
                if (registroPersona.BuscarPorIdentificacion(identificacion) != null)
                {
                    registroPersona.Modificar(personaNueva,identificacion);
                    return $"Se modifico a la persona con la identificacion {identificacion}";
                }
                return $"No se encontro a la persona con identificacion{identificacion}";
            }
            catch (Exception exception)
            {

                return "Ocurrieron los siguientes errores: " + exception.Message;
            }
        }

        public BusquedaReponse Buscar(string identificacion)
        {
            try
            {
                ///Retorna una persona
                return new BusquedaReponse(registroPersona.BuscarPorIdentificacion(identificacion));
                
            }
            catch (Exception exception)
            {
                ///Retorna un string 
                return new BusquedaReponse("Ocurrieron los siguientes errores: " + exception.Message);
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

    public class BusquedaReponse
    {
        public Persona persona { get; set; }

        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public BusquedaReponse(Persona personas)
        {
            personas = personas;
            Error = false;
        }

        public BusquedaReponse(String mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
}
