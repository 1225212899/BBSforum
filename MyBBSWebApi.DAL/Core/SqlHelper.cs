using Microsoft.Data.SqlClient;
using System.Data;

namespace MyBBSWebApi.DAL.Core
{
    public class SqlHelper
    {
        static string connectionString = "server=.;database=MyBBSDb;uid=sa;pwd=123456;Encrypt=False";

        public static DataTable ExecuteTable(string cmdText,params SqlParameter[] sqlParameters)
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.Parameters.AddRange(sqlParameters);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds.Tables[0];           
        }

        public static int ExecuteNonQuery(string cmdText, params SqlParameter[] sqlParameters)
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.Parameters.AddRange(sqlParameters);
            return cmd.ExecuteNonQuery();
        }
    }
}
