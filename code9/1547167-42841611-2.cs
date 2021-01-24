    public static void Main(object[] args)
    {
        CreateDatabaseIfNotExists();
        RunDatabaseUpdateQueries();
        InsertInitialDataIfDatabaseNew();
        // Rest of your code...
    }
