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
    public class DetalleOrdenDAL
    {
        private readonly ConfigurationDAL cn = new ConfigurationDAL();

        public bool Registrar(DetalleOrden detalleOrden)
        {
            bool resp = false;
            try
            {
                cn.connection.Open();
                SqlCommand query = new SqlCommand("INSERT INTO DetalleOrden(IdOrden,IdTipoZapato,Cantidad) VALUES(@param0, @param1, @param2)", cn.connection);
                query.Parameters.AddWithValue("@param0", detalleOrden.IdOrden);
                query.Parameters.AddWithValue("@param1", detalleOrden.IdTipoZapato);
                query.Parameters.AddWithValue("@param2", detalleOrden.Cantidad);

                query.ExecuteNonQuery();
                resp = true;
                cn.connection.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return resp;
        }
    }
}
