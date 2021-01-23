    static IEnumerable<A> GetA()
    {
      using (var db = ConnectionFactory.Current.GetDBConnection())
      {
         return (from a in db.A
                select a).ToArray();
      }
    }
