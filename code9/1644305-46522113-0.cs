     SqlConnectionStringBuilder builder =
             new SqlConnectionStringBuilder
                 {
                   ["Data Source"] = "azureServername.database.windows.net",
                        ["Initial Catalog"] = "databaseName",
                        ["Connect Timeout"] = 30
                 };
        // replace with your server name
        // replace with your database name
    
        string accessToken = TokenFactory.GetAccessToken();
        if (accessToken == null)
        {
             Console.WriteLine("Fail to acuire the token to the database.");
        }
        using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
        {
           try
              {
                   connection.AccessToken = accessToken;
                   connection.Open();
    
                   var commentText = "ALTER TABLE AccountRec ADD newColumn varchar(10) ";
                   SqlCommand sqlCommand = new SqlCommand(commentText, connection);
                       
                   Console.WriteLine("Executed Result:" + sqlCommand.ExecuteNonQuery());
               }
             catch (Exception ex)
             {
                    Console.WriteLine(ex.Message);
             }
          }
          Console.WriteLine("Please press any key to stop");
          Console.ReadKey();
