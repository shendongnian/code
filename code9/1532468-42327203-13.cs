    public class PersonViewModel : INotifyPropertyChanged
    {
        public PersonViewModel()
        {
            Person m0 = new Person() { Name = "person 1", TheType = MyTypes.None };
            Person m1 = new Person() { Name = "person 1", TheType =  MyTypes.IsA };
            Person m2 = new Person() { Name = "person 2", TheType = MyTypes.IsB };
            Person m3 = new Person() { Name = "person 3", TheType = MyTypes.IsC };
            _persons = new ObservableCollection<Person>() { m0, m1, m2, m3 };
            _types = Enum.GetNames(typeof(MyTypes)).ToList();
        }
        List<string> _types;
        public List<string> Types { get { return _types; } } 
        ObservableCollection<Person> _persons;
        public ObservableCollection<Person> Persons { get { return _persons; } set { _persons = value; RaisePropertyChanged("Persons"); } }
 
        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string propname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }
    }
