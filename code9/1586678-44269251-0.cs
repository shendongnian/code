    var query = db.People
                  .Where(person => person.Description.Equals("Client"))
                  .Select(person => new 
                  { 
                      PersonOrders = person.Orders
                                           .Select(order => new 
                                           { 
                                               PersonId = person.Id, 
                                               OrderId = order.Id))
                                           })
                  })
                  .SelectMany(x=>x.PersonOrders)
                  .ToList();
