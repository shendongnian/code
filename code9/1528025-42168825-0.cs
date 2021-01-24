    using (var db = new Context())
    {                
        var project = db.Projects.Include(p => p.Orders).Single(p => p.Id == "myId");
    
        foreach (var toRemove in project.Orders.Where(o =>
                                         ordersToRemove.Select(otr => otr.Id).Contains(o.Id)).ToList())
        {
             project.Orders.Remove(toRemove);
    
        }
        db.SaveChanges();
    }
