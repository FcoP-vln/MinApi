using System;
using System.Collections.Generic;

namespace WebApi.Entidades
{
    public partial class Colaboradore
    {
        public Colaboradore()
        {
            ColaboradorSucursals = new HashSet<ColaboradorSucursal>();
        }

        public int IdColaborador { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Direccion { get; set; }
        public string? Perfil { get; set; }

        public virtual ICollection<ColaboradorSucursal> ColaboradorSucursals { get; set; }
    }
}
