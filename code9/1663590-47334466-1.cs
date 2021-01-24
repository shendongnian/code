    public async void RegisterForNotification()
    {
         var connectionString = @"ConnectionString";
         using (var connection = new SqlConnection(connectionString))
         {
             await connection.OpenAsync();
              var queryString = "Your Query String";
              using (var oCommand = new SqlCommand(queryString, connection))
              {
                  // Starting the listener infrastructure...
                  SqlDependency.Start(connectionString);
                   var oDependency = new SqlDependency(oCommand);
                   oDependency.OnChange += OnNotificationChange;
                   // NOTE: You have to execute the command, or the notification will never fire.
                    await oCommand.ExecuteReaderAsync();
                }
            }
        }
    private void OnNotificationChange(object sender, SqlNotificationEventArgs e)
    {
       Console.WriteLine("Notification Info: " + e.Info);
        //Re-register the SqlDependency. 
       RegisterForNotification();
    }
