    private string GetCountry(uint ipNum)
    {
        string resultStr= null;
        string query = $@"SELECT Country 
                        FROM tb_CountryIP 
                        WHERE {ipNum} >= IP_From 
                          AND {ipNum} <= IP_To";
        try
        {
            using(SqlConnection sqlConn = new SqlConnection(ConnectionStr)) 
            using(SqlCommand sqlComm = new SqlCommand(query, sqlConn))
            {
                sqlConn.Open();
                object result = sqlComm.ExecuteScalar();
                if(result != null)
                    resultStr = result.ToString();
            }
        }
        catch(Exception ex)
        {
            resultStr= $"Error : {ex.Message}";
        }
        return resultStr;
    }
