    static void Main(string[] args)
    {
      using (var context = new TesterEntities())
      {
        var items = context.tePersons.ToList().Select(x => Math.Sin(x.PersonId));        
      }
        Console.ReadLine();
    }
