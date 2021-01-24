    List<Order> orders = new List<Order>();
    orders.Add(new Order() { Id = 1, Name = "Order1" });
    orders.Add(new Order() { Id = 2, Name = "Order2" });
    List<Ticket1> ticket1List = new List<Ticket1>();
    ticket1List.Add(new Ticket1() { Id = 10, OrderId = 1, Value = 2 });
    ticket1List.Add(new Ticket1() { Id = 20, OrderId = 1, Value = 4 });
    List<Ticket2> ticket2List = new List<Ticket2>();
    ticket2List.Add(new Ticket2() { Id = 100, OrderId = 1, Value = 1 });
    ticket2List.Add(new Ticket2() { Id = 200, OrderId = 1, Value = 3 });
    ticket2List.Add(new Ticket2() { Id = 300, OrderId = 2, Value = 5 });
	
    var sumT1 = from o in orders
                from t1 in ticket1List.Where(a => a.OrderId == o.Id).GroupBy(a => a.OrderId)
                select new { OrderId = o.Id, SumT1 = t1.Sum(a => a.Value) };
    var sumT2 = from o in orders
                from t2 in ticket2List.Where(a => a.OrderId == o.Id).GroupBy(a => a.OrderId)
                select new { OrderId = o.Id, SumT2 = t2.Sum(a => a.Value) };
    var list = from o in orders
               from s1 in sumT1.Where(x => x.OrderId == o.Id).DefaultIfEmpty()
               from s2 in sumT2.Where(x => x.OrderId == o.Id).DefaultIfEmpty()
               select new OrderData()
               {
                   OrderName = o.Name,
                   Ticket1Sum = s1?.SumT1 ?? 0,
                   Ticket2Sum = s2?.SumT2 ?? 0			   
               };
