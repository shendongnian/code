    public class Person : INotifyPropertyChanged
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
    
        private string m_firstName;
        public string FirstName
        {
            get { return m_firstName; }
            set
            {
                if (value == m_firstName)
                    return;
    
                m_firstName = value;
                OnPropertyChanged();
            }
        }
    
        private string m_lastName;
        public string LastName
        {
            get { return m_lastName; }
            set
            {
                if (value == m_lastName)
                    return;
    
                m_lastName = value;
                OnPropertyChanged();
            }
        }
    
        private int m_age;
        public int Age
        {
            get { return m_age; }
            set
            {
                if (value == m_age)
                    return;
    
                m_age = value;
                OnPropertyChanged();
            }
        }
    }
