    public class Person
    {
        public Guid Id { get; set; }
        public List<DateTime> Activities { get; set; }
    
        public void AddActivity(int Index, DateTime DateTime) => Activities.Insert(Index, DateTime);
    }
    
    public void Main()
    {
        List<Person> People = new List<Person>();
        Dictionary<Person, DateTime?> MaxDateTimeOfPeople = People.ToDictionary(x => x, x => x.Activities.DefaultIfEmpty().Max(y => new Nullable<DateTime>(y)));
    }
