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
    public class CabeceraOrdenDAL
    {
        private readonly ConfigurationDAL cn = new ConfigurationDAL();

        public CabeceraOrden Registrar(CabeceraOrden cabeceraOrden)
        {
            try
            {
                cn.connection.Open();
                SqlCommand query = new SqlCommand("INSERT INTO CabeceraOrden(IdEmpleado,IdProveedor,FechaIngreso,TotalPares) VALUES(@param0, @param1, @param2, @param3)", cn.connection);
                query.Parameters.AddWithValue("@param0", cabeceraOrden.IdEmpleado);
                query.Parameters.AddWithValue("@param1", cabeceraOrden.IdProveedor);
                query.Parameters.AddWithValue("@param2", cabeceraOrden.FechaIngreso);
                query.Parameters.AddWithValue("@param3", cabeceraOrden.TotalPares);

                query.ExecuteNonQuery();
                cn.connection.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return UltimoReg();
        }

        public CabeceraOrden UltimoReg()
        {
            var cabeceraOrden = new CabeceraOrden();
            try
            {
                cn.connection.Open();
                var query = new SqlCommand("SELECT TOP 1 * FROM CabeceraOrden ORDER BY IdOrden DESC", cn.connection);
                SqlDataReader resp = query.ExecuteReader();
                resp.Read();
                if (resp.HasRows)
                {
                    cabeceraOrden.IdOrden = Convert.ToInt32(resp["IdOrden"]);
                    cabeceraOrden.IdEmpleado = Convert.ToInt32(resp["IdEmpleado"]);
                    cabeceraOrden.IdProveedor = Convert.ToInt32(resp["IdProveedor"]);
                    cabeceraOrden.FechaIngreso = Convert.ToDateTime(resp["FechaIngreso"]);
                    cabeceraOrden.TotalPares = Convert.ToInt32(resp["TotalPares"]);
                }
                cn.connection.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return cabeceraOrden;
        }

    }
}
