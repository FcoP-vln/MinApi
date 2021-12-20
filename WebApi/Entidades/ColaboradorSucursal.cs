using System;
using System.Collections.Generic;

namespace WebApi.Entidades
{
    public partial class ColaboradorSucursal
    {
        public ColaboradorSucursal()
        {
            Viajes = new HashSet<Viaje>();
        }

        public int IdColaboradorSucursal { get; set; }
        public int? IdColaborador { get; set; }
        public int? IdSucursal { get; set; }
        public decimal? Distancia { get; set; }

        public virtual Colaboradore? IdColaboradorNavigation { get; set; }
        public virtual Sucursale? IdSucursalNavigation { get; set; }
        public virtual ICollection<Viaje> Viajes { get; set; }
    }
}
