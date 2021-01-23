    public IList<int> LoadAnimalTypeIdsFromAnimalIdsV2(IList<int> animalIds)
    {
      // This creates an IEnumerable of an anonymous type containing an Id property. This seems
      // to be necessary to be able to grab the Id by it's name via Dapper.
      var namedIDs = animalIds.Select(i => new {Id = i});
      using (var db = new SqlConnection(this.connectionString))
      {
        // This is vital! If you don't open the connection, Dapper will open/close it
        // automagically, which means that you'll loose the created temp table directly
        // after the statement completes.
        db.Open();
        // This temp table is created having a primary key. So make sure you don't pass
        // any duplicate IDs
        db.Execute("CREATE TABLE #tempAnimalIds(animalId int not null primary key);");
        // Using one of Dapper's convenient features, the INSERT becomes:
        db.Execute("INSERT INTO #tempAnimalIds VALUES(@Id);", namedIDs);
        return db.Query<int>(@"SELECT animalID FROM #tempAnimalIds").ToList();
      }
    }
