using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace DAL
{
    public class EmpleadoDAL
    {
        private readonly ConfigurationDAL cn = new ConfigurationDAL();
        public List<Empleado> empleados;

        //Llamada al metodo listar OJO se puede mejorar abstrayendo a otra clase
        public List<Empleado> Listar()
        {
            empleados = new List<Empleado>();
            cn.connection.Open();
            var query = new SqlCommand("SELECT * FROM Empleado WHERE Estado=1", cn.connection);
            SqlDataReader res = query.ExecuteReader();
            Asignacion(res);
            cn.connection.Close();
            return empleados;
        }

        //Asignamiento de los usuarios a la lista
        private void Asignacion(SqlDataReader res)
        {
            while (res.Read())
            {
                empleados.Add(new Empleado {
                    IdEmpleado = Convert.ToInt32(res["IdEmpleado"]),
                    Nombres = res["Nombres"].ToString(),
                    Apellidos = res["Apellidos"].ToString(),
                    Estado = Convert.ToInt32(res["Estado"]),
                    FechaModificacion = Convert.ToDateTime(res["FechaModificacion"])
                });
            }
        }
    }
}
