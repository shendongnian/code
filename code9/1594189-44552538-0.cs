    using (IRepository ceRepository = new DB4Repository(@"Data Source=C:\Data\SQLCE\Test\nw40.sdf"))
    {
      string fileName = Path.GetTempFileName();
      var generator = new Generator4(ceRepository, fileName);
      generator.ScriptDatabaseToFile(Scope.SchemaData);
      using (IRepository serverRepository = new ServerDBRepository4("Data Source=.;Trusted_Connection=true;Initial Catalog=Test"))
      {
          serverRepository.ExecuteSqlFile(fileName);
      }
    }
