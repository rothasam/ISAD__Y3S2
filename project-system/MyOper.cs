using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace project_system
{
    public class MyOper
    {
        public SqlConnection con; // object of class SqlConnection for connect to db
        public void myConnection()
        {
            string str = "Data Source=LAPTOP-0LTH5V9D\\MSSQLSERVER2022; Initial Catalog=db_M7Y325; Integrated Security=true;";
            SqlDependency.Stop(str);
            SqlDependency.Start(str);
            con = new SqlConnection(str);
            con.Open();
        }
    }
}

