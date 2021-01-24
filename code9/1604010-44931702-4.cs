    public class PersonViewModel : PropertyChangedBase
    {
        private Person person;
        public Person Person
        {
            get { return person; }
            set { person = value;
                  NotifyOfPropertyChange(() => FirstName);
                  NotifyOfPropertyChange(() => Surname)};
        }
        public String FirstName
        {
            get { return Person.FirstName; }
            set
            {
                if (Person.FirstName != value)
                {
                    Person.FirstName = value;
                    NotifyOfPropertyChange(() => FirstName);
                }
            }
        }
        public String Surname
        {
            get { return Person.Surname; }
            set
            {
                if (Person.Surname != value)
                {
                    Person.Surname = value;
                    NotifyOfPropertyChange(() => Surname);
                }
            }
        }
    }
