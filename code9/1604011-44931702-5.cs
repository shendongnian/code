    public class PersonViewModel : PropertyChangedBase
    {
        private Person person;
        public Person Person
        {
            get { return person; }
            set { person = value; }
        }
        private String firstName;
        public String FirstName
        {
            get { return firstName; }
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    NotifyOfPropertyChange(() => FirstName);
                }
            }
        }
        private String surname;
        public String Surname
        {
            get { return surname; }
            set
            {
                if (surname != value)
                {
                    surname = value;
                    NotifyOfPropertyChange(() => Surname);
                }
            }
        }
        public void SaveToModel()
        {
            Person.FirstName = FirstName;
            Person.Surname = Surname;
            // trigger EF save?
        }
        public void LoadFromModel()
        {
            FirstName = Person.FirstName;
            Surname = Person.Surname;
        }
    }
