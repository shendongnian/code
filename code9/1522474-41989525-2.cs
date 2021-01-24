    static void Main(string[] args)
    {
      using (var context = new TesterEntities())
      {
        var peopleOrders = context.tePerson.Include("teOrder").First(p => p.PersonId == 1).teOrder.ToList();
        peopleOrders.ForEach(x => Console.WriteLine($"{x.OrderId} {x.Description}"));
      }
    }
