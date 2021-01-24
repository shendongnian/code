    using (SqlConnection mConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
        {
            using (SqlCommand mCommand = new SqlCommand(@"
                INSERT INTO _input_your_tables_name_here 
                            (name, surname, phone, gender, salary, country) 
                     VALUES (@name, @surname, @phone, @gender, @country)", mConnection))
            {
    
                // mCommand.CommandType = CommandType.StoredProcedure;
    
                mCommand.Parameters.AddWithValue("@name", Name);
                mCommand.Parameters.AddWithValue("@surname", Surname);
                mCommand.Parameters.AddWithValue("@phone", Phone);
                mCommand.Parameters.AddWithValue("@gender", Gender);
                mCommand.Parameters.AddWithValue("@salary", Salary);
                mCommand.Parameters.AddWithValue("@country", Country);
    
                try
                {
                    mConnection.Open(); // should net be needed, as using takes care of it
                    mCommand.ExecuteNonQuery(); // should return 1 for 1 row created
                    return "success";
                }
                catch (SqlException e)
                {
                    return e.Message.ToString();
                } 
            }
        }
