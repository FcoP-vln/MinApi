using System;
using System.Collections.Generic;

namespace WebApi.Entidades
{
    public partial class Transportista
    {
        public Transportista()
        {
            Viajes = new HashSet<Viaje>();
        }

        public int IdTransportista { get; set; }
        public decimal? Tarifa { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Viaje> Viajes { get; set; }
    }
}
