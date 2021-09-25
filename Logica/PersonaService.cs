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
                    return "\nDatos guardados correctamente";
                }
                return $"\nLa persona con la identificacion {persona.Identificacion} ya se encuentra registrada.";
                
            }
            catch (Exception exception)
            {

                return "\nOcurrieron los siguientes errores: " + exception.Message;
            }
        }

        public string Eliminar(string identificacion)
        {
            try
            {
                if (registroPersona.BuscarPorIdentificacion(identificacion)!=null)
                {
                    registroPersona.Eliminar(identificacion);
                    return $"\nSe elimino a la persona con la identificacion {identificacion}";
                }
                return $"\nNo se encontro a la persona con identificacion{identificacion}";
            }
            catch (Exception exception)
            {

                return "\nOcurrieron los siguientes errores: " + exception.Message;
            }
        }

        public string Modificar(Persona personaNueva, string identificacion)
        {
            try
            {
                if (registroPersona.BuscarPorIdentificacion(identificacion) != null)
                {
                    registroPersona.Modificar(personaNueva,identificacion);
                    return $"\nSe modifico a la persona con la identificacion {identificacion}";
                }
                return $"\nNo se encontro a la persona con identificacion{identificacion}";
            }
            catch (Exception exception)
            {

                return "\nOcurrieron los siguientes errores: " + exception.Message;
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
                return new BusquedaReponse("\nOcurrieron los siguientes errores: " + exception.Message);
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
                return new ConsultaResponse("\nOcurrieron los siguientes errores: " + exception.Message);
            }
        }
    }

    public class ConsultaResponse
    {
        public List<Persona> Personas { get; set; }

        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public ConsultaResponse(List<Persona> personas)
        {
            Personas = personas;
            Error = false;
        }

        public ConsultaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }

    public class BusquedaReponse
    {
        public Persona Persona { get; set; }

        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public BusquedaReponse(Persona persona)
        {
            Persona = persona;
            Error = false;
        }

        public BusquedaReponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
}
