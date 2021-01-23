    public class OtherPerson
    {
      public int PersonId { get; set; }
      public string PersonLongName { get; set; }
      public teOrder Order { get; set; }
    }
    static void Main(string[] args)
    {
      using (var context = new TesterEntities())
      {
        //Say I just want to project a new object with a select starting from orders and then traversing up.  Not too hard
        var newObjects = context.teOrders.Where(order => order.OrderId == 1)
          //SelectMan will FLATTEN a list off of a parent or child in a one to many relationship
          .SelectMany(peopleInOrderOne => peopleInOrderOne.tePersons)
          .ToList()
          .Select(existingPerson => new OtherPerson
          {
            PersonId = existingPerson.PersonId,
            PersonLongName = $"{existingPerson.FirstName} {existingPerson.LastName}",
            Order = existingPerson.teOrder
          })
          .ToList();
        newObjects.ForEach(newPerson => Console.WriteLine($"{newPerson.PersonId} {newPerson.PersonLongName} {newPerson.Order.Description}"));
        // Just an action clause to repeat find items in my context, the important thing to note is that y extends teOrder which is another POCO inside my POCO
        Action<string, List<tePerson>> GetOrdersForPeople = (header, people) => 
        {
          Console.WriteLine(header);
          people.ForEach(person => Console.WriteLine($"{person.FirstName} {person.LastName} {person.teOrder.Description}"));
          Console.WriteLine();
        };
        //I want to look at a person and their orders.  I don't have to do multiple selects down, lazy loading by default gives me a child object off of EF
        GetOrdersForPeople("First Run", context.tePersons.ToList());
        
        //Say I want a new order for a set of persons in my list?
        var newOrder = new teOrder { Description = "Shoes" };
        context.teOrders.Add(newOrder);
        context.SaveChanges();
        //Now I want to add the new order
        context.tePersons.SingleOrDefault(person => person.PersonId == 1).teOrder = newOrder;
        context.SaveChanges();
        //I want to rexamine now
        GetOrdersForPeople("After changes", context.tePersons.ToList());
        //My newOrder is in memory and I can alter it like clay still and the database will know if I change the context
        newOrder.Description = "Athletic Shoes";
        context.SaveChanges();
        GetOrdersForPeople("After changes 2", context.tePersons.ToList());
        //Say I want to update a few people with new orders at the same time
        var peopleBesidesFirst = context.tePersons.Where(person => person.PersonId != 1).ToList();
        var firstPersonInList = context.tePersons.Where(person => person.PersonId == 1).ToList();
        var newOrders = new List<teOrder> {
          new teOrder { Description = "Hat", tePersons = peopleBesidesFirst },
          new teOrder { Description = "Tie", tePersons = firstPersonInList }
          };
        context.teOrders.AddRange(newOrders);
        context.SaveChanges();
        GetOrdersForPeople("After changes 3", context.tePersons.ToList());
      }
      Console.ReadLine();
    }
