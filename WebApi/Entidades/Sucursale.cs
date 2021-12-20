using System;
using System.Collections.Generic;

namespace WebApi.Entidades
{
    public partial class Sucursale
    {
        public Sucursale()
        {
            ColaboradorSucursals = new HashSet<ColaboradorSucursal>();
        }

        public int IdSucursal { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }

        public virtual ICollection<ColaboradorSucursal> ColaboradorSucursals { get; set; }
    }
}
