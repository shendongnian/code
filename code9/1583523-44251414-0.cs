    string GetOrderSummaries()
    {
       // First, you just query the orders and eager fetch the status.
       // The eager fetch is just to avoid a Select N+1 when traversing the returned list.
       // With that, we make sure we will execute only one query (it will be a join).
       var query = session.QueryOver<Order>()
                          .Fetch(o => o.Status).Eager;
    
       // This executes your query and creates a list of orders.
       var orders = query.List();
    
       // We map these orders to DTOs, here I'm doing it manually.
       // Ideally, have one DTO for Order (OrderSummary) and one for OrderStatus (OrderSummaryStatus).
       // As mentioned by the other commenter, you can use (for example) AutoMapper to take care of this for you:
       var orderSummaries = orders.Select(order => new OrderSummary
       {
          Id = order.Id,
          Status = new OrderSummaryStatus
          {
             Id = order.Status.Id,
             Name = order.Status.Name
          }
       }).ToList();
    
       // Yes, it is true that this implied that we not only materialized the entities, but then went over the list a second time.
       // In most cases I bet this performance implication is negligible (I imagine serializing to Json will possibly be slower than that).
       // And code is more terse and possibly more resilient.
    
       // We serialize the DTOs to Json with, for example, Json.NET
       var orderSummariesJson = JsonConvert.SerializeObject(orderSummaries);
       return orderSummariesJson;
     }
