using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class EmpleadoBL
    {
        private EmpleadoDAL empleadoDAL = new EmpleadoDAL();

        public List<Empleado> Listar()
        {
            return empleadoDAL.Listar();
        }
    }
}
