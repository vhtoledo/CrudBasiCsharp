using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDBASIC
{
    internal class BD
    {
        // conexión bd
        public static SqlConnection Conexion()
        {
            SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=RegistroEmpleados;Integrated Security=True");
            connection.Open();
            return connection;
        }
    }
}
