    [Route("api/Login")]
    public void Post([FromBody]login loginmodel)
            {
                try
                {
                    using (SqlConnection df = new SqlConnection(connStr))
                    {
                        using (SqlCommand de = new SqlCommand())
                        {
                            de.CommandType = System.Data.CommandType.StoredProcedure;
                            de.CommandText = "StoreImageDetails";
                            de.Connection = df;
                            de.Parameters.Add(new SqlParameter("@name", loginmodel.name));
                            de.Parameters.Add(new SqlParameter("@username", loginmodel.username));
                            de.Parameters.Add(new SqlParameter("@email", loginmodel.email));
                            de.Parameters.Add(new SqlParameter("@password", loginmodel.password));
                            df.Open();
                            var dt = de.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ed)
                {
                    //ed+Message;    
                }
            }
