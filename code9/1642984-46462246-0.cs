      public class Event
    {
        public int EventID { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public System.DateTime Start { get; set; }
        public Nullable<System.DateTime> End { get; set; }
        public string ThemeColor { get; set; }
        public bool IsFullDay { get; set; }
    }
    public partial class MyDatabaseEntities : DbContext
        {
            public MyDatabaseEntities()
                : base("name=MyDatabaseEntities")
            {
            }
            public virtual DbSet<Event> Events { get; set; }
        }
  
