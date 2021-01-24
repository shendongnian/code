        SqlConnection conn;
            using(conn = new SqlConnection(@"Data Source=;Initial Catalog=;User ID = sa;Password="))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("testprocedure", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter retValue = command.Parameters.Add("return", SqlDbType.Int);
                    retValue.Direction = ParameterDirection.ReturnValue;
                    command.ExecuteNonQuery();
                    Console.WriteLine("no of records affected " + retValue.Value);
                    Console.ReadLine();
                }
            } 
