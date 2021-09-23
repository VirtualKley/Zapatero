using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class DetalleOrdenBL
    {
        public DetalleOrdenDAL detalleOrdenDAL = new DetalleOrdenDAL();

        public bool Registrar(DetalleOrden detalleOrden)
        {
            return detalleOrdenDAL.Registrar(detalleOrden);
        }
    }
}
