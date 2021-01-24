    if (internationalarrival.AgentName == null)
                {
    
                    internationalarrival.AgentName = internationalarrival.AgentNameNew;
                }
    
                if (internationalarrival.AgentName != null)
                {
    
                    internationalarrival.AgentName = internationalarrival.AgentName;
                
                }
                db.InternationalArrivals.Add(internationalarrival);
                db.SaveChanges();
