    foreach(var item in ListItems)
    {
      context.Entry(item).State = System.Data.EntityState.Added;
      context.Add(item);
    }
    
    context.SaveChanges();
    
