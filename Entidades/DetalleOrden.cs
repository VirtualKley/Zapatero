using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleOrden
    {
        public int IdOrden { get; set; }
        public int? IdOrdenDetalle { get; set; }
        public int IdTipoZapato { get; set; }
        public int Cantidad { get; set; }
        public CabeceraOrden CabeceraOrden { get; set; }
        public TipoZapato TipoZapato { get; set; }
    }
}
