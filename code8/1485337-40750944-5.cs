    int retryCount = 0;
            using (SqlCommand myCommand = new SqlCommand("MyStoredProcedure", new SqlConnection("Server=.;Database=MyDatabase;Trusted_Connection=True;")))
            {
                while (retryCount < 10)
                {
                    try
                    {
                        if (myCommand.Connection.State == ConnectionState.Closed)
                        {
                            myCommand.Connection.Open();
                        }
    
                        myCommand.CommandType = CommandType.StoredProcedure;
                        myCommand.ExecuteNonQuery();
    
                    }
                    catch (Exception ex)
                    {
                        retryCount++;
                        System.Threading.Thread.Sleep(1000);
                    }
                }
            }
