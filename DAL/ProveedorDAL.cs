using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProveedorDAL
    {
        private readonly ConfigurationDAL cn = new ConfigurationDAL();
        public List<Proveedor> proveedores;

        public List<Proveedor> Listar()
        {
            proveedores = new List<Proveedor>();
            cn.connection.Open();
            var query = new SqlCommand("SELECT * FROM Proveedor WHERE Estado=1", cn.connection);
            SqlDataReader res = query.ExecuteReader();
            Asignacion(res);
            cn.connection.Close();
            return proveedores;
        }

        //Asignamiento de los usuarios a la lista
        private void Asignacion(SqlDataReader res)
        {
            while (res.Read())
            {
                proveedores.Add(new Proveedor
                {
                    IdProveedor = Convert.ToInt32(res["IdProveedor"]),
                    Nombre = res["Nombre"].ToString(),
                    Estado = Convert.ToInt32(res["Estado"]),
                    FechaModificacion = Convert.ToDateTime(res["FechaModificacion"])
                });
            }
        }
    }
}
