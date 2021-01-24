    public class PersonViewModel : INotifyPropertyChanged
    {
        public PersonViewModel()
        {
            Person m1 = new Person() { Name = "person 1", IsSentenced = false, Sentence = "S S S" };
            Person m2 = new Person() { Name = "person 2", IsSentenced = false, Sentence = "B B B" };
            Person m3 = new Person() { Name = "person 3", IsSentenced = true, Sentence = "F F F" };
            _persons = new ObservableCollection<Person>() { m1, m2, m3 }; 
        } 
        ObservableCollection<Person> _persons;
        public ObservableCollection<Person> Persons { get { return _persons; } set { _persons = value; RaisePropertyChanged("Persons"); } }
 
        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string propname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }
    }
