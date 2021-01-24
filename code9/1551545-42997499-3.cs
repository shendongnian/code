    public TodoItemDatabase(string dbPath)
    {
      database = new SQLiteAsyncConnection(dbPath);
      database.CreateTableAsync<TodoItem>().Wait();
    }
