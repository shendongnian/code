    public class MyViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Impl
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    
        private List<Person> m_people;
        public List<Person> People
        {
            get { return m_people; }
            private set
            {
                if (value == m_people)
                    return;
    
                m_people = value;
                OnPropertyChanged();
            }
        }
    
        public MyViewModel()
        {
            m_people = new List<Person>()
            {
                new Person() { FirstName = "Bob", LastName = "Brown", Age = 45 },
                new Person() { FirstName = "Sarah", LastName = "Smith", Age = 25 }
            };
    
            foreach (var person in m_people)
            {
                person.PropertyChanged += person_PropertyChanged;
            }
        }
    
        //Property Changed will be called whenever a property of one of the 'Person'
        //objects is changed.
        private void person_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var row = sender as Person;
            SaveData(row);
        }
    
        private void SaveData(Person row)
        {
            //Save the row to the database here.
        }
    }
