    public class EventsRepository : Repostitory<Event>, IEventsRepository
    {
        public EventsRepository(ApplicationDbContext context) : base(context)
        {
    
        }
    }
