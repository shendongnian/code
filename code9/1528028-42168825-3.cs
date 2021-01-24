        using (var db = new Context())
        {                
            var project = db.Projects.Single(p => p.Id == "myId");
        
            foreach (var toRemove in project.Orders.Where(o =>
                                             ordersToRemove.Select(otr => otr.Id).Contains(o.Id)).ToList())
            {
                 db.Orders.Remove(toRemove); //UPDATE: remove orders from context
        
            }
            db.SaveChanges();
        }
