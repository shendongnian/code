    using(var myContext = new MyContext)
    {
       var agent = new Agent() { AgentId = 838388 };
       myContext.Agents.Attach(agent);
       var listing = new Listing() { ... };
       listing.Agents.Add(agent);
       myContext.Listings.AddObject(listing);
       myContext.SaveChanges();
    }
