    public DataTable GetRandomQuestionByCateId(string id, int z)
    {
        DataTable resultData;
        String sqlProcedure = "GetRandomQuest";
        using (SqlConnection cn = new SqlConnection("Your connection string here")) 
        {
           using (SqlCommand cmd = new SqlCommand(sql, cn)) 
           {
              cmd.CommandType = CommandType.StoredProcedure;
              cmd.Parameters.Add("@a", SqlDbType.VarChar, 50).Value = a;
              cmd.Parameters.Add("@z", SqlDbType.int).Value = z;   
              SqlDataAdapter da = new SqlDataAdapter(cmd);
              da.Fill(resultData);          
           }
        }
        return resultData;
    }
