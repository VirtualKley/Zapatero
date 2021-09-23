using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ProveedorBL
    {
        private ProveedorDAL proveedorDAL = new ProveedorDAL();

        public List<Proveedor> Listar()
        {
            return proveedorDAL.Listar();
        }
    }
}
