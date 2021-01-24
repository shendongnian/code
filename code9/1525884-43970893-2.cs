    public static DataTable ExecuteDataTableSqlDA(SqlConnection conn, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
    {
       System.Data.DataTable dt = new DataTable();
       System.Data.SqlClient.SqlDataAdapter da = new SqlDataAdapter(cmdText, conn);
       da.Fill(dt);
       return dt;
    }
