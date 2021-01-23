    static IEnumerable<A> GetA(whatevertype db)
    {
       return from a in db.A
              select a;
    }
    static B[] DoSmth()
    {
      using (var db = ConnectionFactory.Current.GetDBConnection())
      {
        var aItems = GetA(db);
        if (!aItems.Any())
          return null;
        return aItems.Select(a => new B(a.prop1)).ToArray();
      }
    }
