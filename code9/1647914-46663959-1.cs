    class MainViewModel : ObservableObject
    {
        public List<Person> pList { get; }
    
        public MainViewModel()
        {
            pList = new List<Person>()
            {
                new Person() {FirstName="Craig"}
            };
        }
    }
