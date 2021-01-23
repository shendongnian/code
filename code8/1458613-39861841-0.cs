    private type m_name;
        public type name
        {
            get { return m_name; }
            set
            {
                m_name = value;
                if (PropertyChanged != null)
                { PropertyChanged(this, new PropertyChangedEventArgs("name")); }
            }
        }
