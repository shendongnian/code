    public class School
    {
        public int Id;
        public string Name;
        private List<Person> _persons;
        public School()
        {
            _persons = new List<Person>();
        }
    }
