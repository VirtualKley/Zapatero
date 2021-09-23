using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class TipoZapatoBL
    {
        private TipoZapatoDAL tipoZapatoDAL = new TipoZapatoDAL();

        public List<TipoZapato> Listar()
        {
            return tipoZapatoDAL.Listar();
        }
    }
}
