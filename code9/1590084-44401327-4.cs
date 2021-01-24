    public class SO 
    {
        List<List<Event>> events;
        public override string ToString()
        {
             return string.Join(", ", 
                 events.SelectMany((list) => list)
                     .Select((ev) => ev.ToString()));
        }
    }
