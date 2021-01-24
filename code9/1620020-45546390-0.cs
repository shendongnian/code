    public class Person : IDataErrorInfo, INotifyPropertyChanged
    {
        private readonly IValidator _validator;
        public Person(IValidator validator)
        {
            _validator = validator;
        }
        private string m_name;
        public string Name
        {
            get { return m_name; }
            set
            {
                m_name = value;
                OnPropertyChanged();
            }
        }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Name":
                        if (string.IsNullOrEmpty(Name))
                        {
                            /** This one works, but from here I cannot compare with names of other Person objects. **/
                            return "The name cannot be empty.";
                        }
                        else
                        {
                            return _validator.Validate(this);
                        }
                    default:
                        return string.Empty;
                }
            }
        }
        public string Error { get; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public interface IValidator
    {
        string Validate(Person person);
    }
    public class RegisteredPeople : IValidator
    {
        public ObservableCollection<Person> People { get; set; }
        public Person SelectedPerson { get; set; }
        public string Validate(Person person)
        {
            if (person != null && People.Any(x => x != person && x.Name == person.Name))
                return "Same name!";
            return null;
        }
        public RegisteredPeople()
        {
            People = new ObservableCollection<Person>() {
            new Person(this) {Name = "Ramzi", Address = "A1", Phone = "1"},
            new Person(this) {Name = "Frank", Address = "A2", Phone = "12"},
            new Person(this) {Name = "Ihab", Address = "A3", Phone = "123"}
        };
        }
    }
