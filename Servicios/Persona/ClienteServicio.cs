﻿using Dominio.UnidadDeTrabajo;
using IServicio.Persona;
using System.Linq;

namespace Servicios.Persona
{
    public class ClienteServicio : PersonaServicio, IClienteServicio
    {
        public ClienteServicio(IUnidadDeTrabajo unidadDeTrabajo) 
            : base(unidadDeTrabajo)
        {

        }

        public int ObtenerCantidadClientes()
        {
            return _unidadDeTrabajo.ClienteRepositorio.Obtener().Count();
        }
    }
}
