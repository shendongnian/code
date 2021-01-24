    class MainViewModel : ObservableObject
    {
        public List<Person> pList { get; } new List<Person>();
    
        public MainViewModel()
        {
            pList = new List<Person>()
            {
                new Person() {FirstName="Craig"}
            };
            Init();
        }
        public void Init()
        {
            var li = pList.FirstOrDefault();
        }
    }
