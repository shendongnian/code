    public class People
    {
        public int PeronId { get; set; }
        public string Name { get; set; }
        public City City { get; set; }
        public IList<PersonVotes> PersonVoes { get; set; }
    }
    public class PersonVotes
    {
        public int Vote { get; set; }
    }
    public class City
    {
        public string Name { get; set; }
    }
    public class FirstAdminDivision
    {
        public string Name { get; set; }
    }
    public class PersonModel
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string LocationDisplay { get; set; }
        public double AverageVote { get; set; }
    }
