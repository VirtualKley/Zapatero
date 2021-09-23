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
    public class TipoZapatoDAL
    {
        private readonly ConfigurationDAL cn = new ConfigurationDAL();
        public List<TipoZapato> tzapato;

        //Llamada al metodo listar OJO se puede mejorar abstrayendo a otra clase
        public List<TipoZapato> Listar()
        {
            tzapato = new List<TipoZapato>();
            cn.connection.Open();
            var query = new SqlCommand("SELECT * FROM TipoZapato WHERE Estado=1", cn.connection);
            SqlDataReader res = query.ExecuteReader();
            Asignacion(res);
            cn.connection.Close();
            return tzapato;
        }

        //Asignamiento de los usuarios a la lista
        private void Asignacion(SqlDataReader res)
        {
            while (res.Read())
            {
                tzapato.Add(new TipoZapato
                {
                    IdTipoZapato = Convert.ToInt32(res["IdTipoZapato"]),
                    Nombre = res["TipoZapato"].ToString(),
                    Estado = Convert.ToInt32(res["Estado"]),
                    FechaModificacion = Convert.ToDateTime(res["FechaModificacion"])
                });
            }
        }
    }
}
