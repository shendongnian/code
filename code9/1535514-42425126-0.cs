    public SomeClass
    {
      public string UniqueIdNo {get;set;}
      public string RmaNumber {get;set;}
    }
    
    var data = new List<SomeClass>();
    while (pgReader.Read())
    {
      var someClass = new SomeClass();
      someClass.UniqueIdNo = pgReader.GetString(0);
      someClass.RmaNumber = pgReader.GetString(1);
      data.Add(someClass);
    }
