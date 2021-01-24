    public PersonCollection : IList<Person> // or ICollection<IPerson>
    {
        private readonly List<IPerson> innerList = new List<IPerson>();
        // example implementation of IList.Add
        public void Add (IPerson person)
        {
             innerList.Add(person);
        }
        // implement the other interface methods accordingly
        // extend functionality with your methods 
        public async Task AddAsync(IPerson person) // note async naming convention
        {
            // your async add implementaion
        }
 
    }
