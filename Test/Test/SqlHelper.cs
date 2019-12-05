using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public static class SqlHelper
    {
        private static readonly string sqlConn = "";
        public static int ExcuteNonQuery(string sql,params SqlParameter[] paras)
        {
            using (SqlConnection conn = new SqlConnection(sqlConn))
            {
                using (SqlCommand cmd = new SqlCommand(sql,conn))
                {
                    if (paras != null)
                    {
                        cmd.Parameters.AddRange(paras);
                    }
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
