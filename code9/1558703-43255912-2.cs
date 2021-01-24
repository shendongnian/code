    static void Main(string[] args) {
        var cs = "connection string";        
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("select ErrorCode from dbo.Error", connection);
            SqlDependency dependency = new SqlDependency(command);
            dependency.OnChange += OnChange;
            SqlDependency.Start(cs);
            command.ExecuteReader().Dispose();                
        }
        Console.ReadKey();
    }
    private static void OnChange(object sender, SqlNotificationEventArgs e) {
        Console.WriteLine(e.Info);
    }
