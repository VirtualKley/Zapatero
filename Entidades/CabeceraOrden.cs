using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CabeceraOrden
    {
        public int IdOrden { get; set; }
        public int IdEmpleado { get; set; }
        public int IdProveedor { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int TotalPares { get; set; }
        public Empleado Empleado { get; set; }
        public Proveedor Proveedor { get; set; }
        public List<DetalleOrden> DetalleOrden { get; set; }
    }
}
