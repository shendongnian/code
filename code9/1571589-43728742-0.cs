    using (MyDataContext dc = new MyDataContext())
    {
      Person p = new Person();
      Order o = new Order();
      p.Orders.Add(o); //connect the objects into an object graph.
    
      dc.Persons.Add(p); //add the graph to the data context
      dc.SubmitChanges();  //save it all.
    }
