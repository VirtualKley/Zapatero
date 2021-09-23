using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ConfigurationDAL
    {
        public readonly SqlConnection connection;
        public ConfigurationDAL()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString);
        }
    }
}
