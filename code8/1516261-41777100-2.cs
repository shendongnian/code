    using System.Configuration;
    [WebMethod]
    public static bool GetCurrentToBin(string ToBin)
    {
        var connectionString = ConfigurationManager.ConnectionStrings["SqlConn"].ToString();
        using(var conn = new SqlConnection(connectionString))
        {
            const string queryString = "sp_P_WMS_Stock_Adj_Validation_Proc @Bin";
            var sqlCommand = new SqlCommand(queryString , conn);
            sqlCommand.Parameters.AddWithValue("@Bin",ToBin);
            conn.Open();
            var reader = sqlCommand.ExecuteReader();
    
            return reader.Read();
        }
    }
