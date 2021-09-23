using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CabeceraOrdenBL
    {
        private CabeceraOrdenDAL cabeceraOrdenDAL = new CabeceraOrdenDAL();

        public CabeceraOrden Registrar(CabeceraOrden cabeceraOrden)
        {
            return cabeceraOrdenDAL.Registrar(cabeceraOrden);
        }
    }
}
