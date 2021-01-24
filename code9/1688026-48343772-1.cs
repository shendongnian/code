    public class EntitiesContainer
    {
        public IEnumerable<Address> Addresses { get; set; } = new List<Address>;
        public IEnumerable<Person> People { get; set; } = new List<Address>;
        public IEnumerable<Contract> Contracts { get; set; } = new List<Address>;
    }
