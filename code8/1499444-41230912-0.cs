    // C#
      using (SqlConnection sqlcon = new SqlConnection("Server=localhost; Database=Northwinds; Integrated Security=true;"))
                {
                    sqlcon.Open();
                    SqlCommand sqlcom = new SqlCommand();
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.CommandText = "myProcedure";
                    sqlcom.Parameters.Add("@param1", SqlDbType.Int).Value = 254;
    
                    // this can be named anything I just used @r
                    SqlParameter returnParameter = sqlcom.Parameters.Add("@r", SqlDbType.Int);
                    // specify parameter is a return
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    sqlcom.Connection = sqlcon;
                    sqlcom.ExecuteNonQuery();
    
                    // get return value
                    int result = (int)sqlcom.Parameters["@r"].Value ;
                    sqlcon.Close();
                }
