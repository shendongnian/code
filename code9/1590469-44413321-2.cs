    using System.ComponentModel;
    
    namespace TestWpf
    {
        class MyValidatorProperties : INotifyPropertyChanged
        {
            private string m_myName = "";
    
            public string myName
            {
                get
                {
                    return m_myName;
                }
                set
                {
                    if (m_myName != value)
                    {
                        m_myName = value;
                        OnPropertyChanged("myName");
                    }
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged(string info)
            {
                PropertyChanged?.Invoke(null, new PropertyChangedEventArgs(info));
            }
        }
    }
