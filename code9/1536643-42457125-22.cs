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
    
        private ObservableCollection<Person> m_people;
        public ObservableCollection<Person> People
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
            m_people = new ObservableCollection<Person>();
            m_people.CollectionChanged += m_people_CollectionChanged;
            m_people.Add(new Person() { FirstName = "Bob", LastName = "Brown", Age = 45 });
            m_people.Add(new Person() { FirstName = "Sarah", LastName = "Smith", Age = 25 });
        }
    
        private void m_people_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count > 0)
            {
                foreach (INotifyPropertyChanged item in e.NewItems.OfType<INotifyPropertyChanged>())
                {
                    item.PropertyChanged += people_PropertyChanged;
                }
            }
            if (e.OldItems != null && e.OldItems.Count > 0)
            {
                foreach (INotifyPropertyChanged item in e.OldItems.OfType<INotifyPropertyChanged>())
                {
                    item.PropertyChanged -= people_PropertyChanged;
                }
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
