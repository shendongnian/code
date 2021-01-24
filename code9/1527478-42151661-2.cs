    bool CheckIsExisting(object value, string valueToCompareWith) 
    {
        using (var conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("some_stored_procedure", conn))
           {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("input", value));
                using (var adapter = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    if (ds.Tables.Count != 0 && ds.Tables[0].Rows.Count != 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            if (row["Key"].ToString() == ValueToCompareWith)
                            {
                                return true;
                            }
                        }
                   }
               }
           }
        }
        return false;
    }
         
