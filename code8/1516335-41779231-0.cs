    public class EventsRepository : Repostitory<Event>
    {
        public EventsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
