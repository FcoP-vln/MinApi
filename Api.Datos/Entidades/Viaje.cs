using System;
using System.Collections.Generic;

namespace Api.Datos.Entidades
{
    public partial class Viaje
    {
        public int IdViajes { get; set; }
        public int? IdColaboradorSucursal { get; set; }
        public int? IdTransportista { get; set; }
        public decimal? Pago { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual ColaboradorSucursal? IdColaboradorSucursalNavigation { get; set; }
        public virtual Transportista? IdTransportistaNavigation { get; set; }
    }
}
