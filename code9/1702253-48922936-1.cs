    private int ExecuteInsertInto(string query, List<SqlParameter> prms = null)
    {
       using(SqlConnection cnn = new SqlConnection(..connectionstring goes here..))
       using(SqlCommand cmd = new SqlCommand(query))
       {
            cnn.Open();
            if(prms != null)
                cmd.Parameters.AddRange(prms.ToArray());
            return cmd.ExecuteNonQuery();
       }
    }
  
