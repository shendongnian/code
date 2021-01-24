    IObservable<Event> CreateSimulation(IEnumerable<Event> events)
    {
         IEnumerable<Event> simulation()
         {
             foreach(var ev in events)
             {
                 var now = DateTime.UtcNow;
                 if(ev.Timestamp > now)
                 {
                     Thread.Sleep(ev.Timestamp - now);
                 }
                 yield return ev;          
            }
        }
        return simulation().ToObservable();
    }
