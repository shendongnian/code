    string userName = "mate";
    string fullName = string.Empty;
    string connectionString = @"your connection string here";
    string query = "SELECT Nev FROM Login WHERE username='@UserName';";
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
         SqlCommand command = new SqlCommand(query, connection);
         command.Parameters.Add("@UserName", SqlDbType.NVarChar);
         command.Parameters["@UserName"].Value = userName;
         try
         {
             connection.Open();
             fullName = command.ExecuteScalar().ToString();
         }
         catch (Exception ex)
         {
             Console.WriteLine(ex.Message);
         }
    }
    Console.WriteLine("Hello {0}!", fullName);
