using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoZapato
    {
        public int IdTipoZapato { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
