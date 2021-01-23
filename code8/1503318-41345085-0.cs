    public class EventsHelper
        {
            IRepository repo;
        
            public EventsHelper(IRepository repository)
            {
                repo = repository;          
            }
            public IEnumerable<Event> GetEvents()
            {
                return repo.Events;
            }  
        
          public List<Event> eventList {get; set;}
        }
