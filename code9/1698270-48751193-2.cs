    private ProfileBO retrieveSingleProfile(string termField, string termValue)
        {
          try {
            ProfileBO profile = new ProfileBO();
           //Query string is temporary.  Will make this a stored procedure.
            string queryString = " SELECT * FROM GamePresenterDB.gp.Profile WHERE " + termField + " = '" + termValue + "'";
            using (SqlConnection connection = new SqlConnection(App.getConnectionString()))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())                
                {
                    profile = castDataReadertoProfileBO(reader, profile);
                } 
                else
                {
                    // No record was selected.  log it and throw the exception (We'll log it later, for now just write to console.)
                    Console.WriteLine("No record was selected from the database for method retrieveSingleProfile()");
                    throw new InvalidOperationException("An exception occured.  No data was found while trying to retrienve a single profile.");
                }
                reader.Close();
            }
            return profile;
           }
          catch(InvalidOperationException e)
          { 
          }
        }
