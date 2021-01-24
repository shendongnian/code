    public class MainViewModel
    {
        public MainViewModel()
        {
            //Initializing collections
            Coll1 = new ObservableCollection<Employee> {
                new Employee { Name = "Coll1" },
                new Employee { Name = "Coll1" },
                new Employee { Name = "Coll1" },
            };
            Coll2 = new ObservableCollection<Employee> {
                new Employee { Name = "Coll2" },
                new Employee { Name = "Coll2" },
                new Employee { Name = "Coll2" },
            };
            Coll3 = new ObservableCollection<Employee> {
                new Employee { Name = "Coll3" },
                new Employee { Name = "Coll3" },
                new Employee { Name = "Coll3" },
            };
    
            Collection.Add(Coll1);
            Collection.Add(Coll2);
            Collection.Add(Coll3);
        }
        //collection1
        public ObservableCollection<Employee> Coll1 { get; set; }
        //collection2
        public ObservableCollection<Employee> Coll2 { get; set; }
        //collection3
        public ObservableCollection<Employee> Coll3 { get; set; }
    
        public ObservableCollection<object> Collection { get; set; } = new ObservableCollection<object>();
    
