using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WCFREST
{
    public class DatabaseService
    {
        private const String sqlConString = "Data Source=kasper.database.windows.net;Initial Catalog=DB;Integrated Security=False;User ID=Kasper;Password=Kylling123;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static SqlConnection SqlCon()
        {
            SqlConnection con = new SqlConnection(sqlConString);
            con.Open();
            return con;
        }
    }
}