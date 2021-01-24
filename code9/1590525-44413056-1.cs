    public void QueryExecution(string SQLQuery)
    { 
        RSProfile profile = new RSProfile();
        RSDatabaseConnectionCreator instance = new RSDatabaseConnectionCreator(profile);
        SqlConnection conn = instance.CreateConnection(...);
        SqlCommand command = new SqlCommand(SQLQuery, conn);
        var file = new StreamWriter(@"D:\Project\rsDeployer\ImportedQuery.txt");
        file.WriteLine(command);
        file.Close();
        conn.Close();
    }
