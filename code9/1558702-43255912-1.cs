    SqlDependency.Start(connectionString);
    string commandText = "SELECT status From dbo.tableTask"; // don't forget schema here
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new SqlCommand(commandText, connection);
        SqlDependency dependency = new SqlDependency(command);
        dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);    
        command.ExecuteReader().Dispose();
        objNotificationHub = new NotificationHub();
    }
