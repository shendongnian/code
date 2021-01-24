    static TodoItemDatabase database;
    
    public static TodoItemDatabase Database
    {
      get
      {
        if (database == null)
        {
          database = new TodoItemDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3"));
        }
        return database;
      }
    }
