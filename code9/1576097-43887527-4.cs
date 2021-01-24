    public class Group
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public virtual ICollection<Event> PersonGroup { get; set; }
        [NotMapped]
        public IEnumerable<Person> PersonsInGroupEvents
        {
            return PersonGroup.Select(ev => ev.Person);
        }
    }
    // or fluent api way of NotMapped:
    modelBuilder.Entity<Group>()
        .Ignore(x => x.PersonsInGroupEvents);
