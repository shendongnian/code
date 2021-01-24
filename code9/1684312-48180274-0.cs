    public int InsertTableThree(int IdTableOne,int IdTableTwo)
        {
                    string connectionString = WebConfigurationManager.AppSettings["MyString"];
                    string queryString = "INSERT INTO TableThree (IdTableOne,IdTableTwo) VALUES(@IdTableOne,@IdTableTwo)";
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        //connection.Open();
                        using (SqlCommand comm = new SqlCommand(queryString, con))
                        {
                            try
                            {
                                    comm.Parameters.AddWithValue("@IdTableOne", IdTableOne);
                                    comm.Parameters.AddWithValue("@IdTableTwo", IdTableTwo);
                                    comm.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
                    return IdTableOne;
        }
    
      
