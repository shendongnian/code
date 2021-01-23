    class ExampleObject : INotifyPropertyChanged {
        private int m_value1;
        private int m_value2;
        public int Value1 {
            get {
                return m_value1;
            }
            set {
                if (value != m_value1) {
                    m_value1 = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(Value1));
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(Sum));
                }
            }
        }
        public int Value2 {
            get {
                return m_value2;
            }
            set {
                if (value != m_value2) {
                    m_value2 = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(Value2));
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(Sum));
                }
            }
        }
        public int Sum {
            get {
                return m_value1 + m_value2;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
    }
