    class TestObject : INotifyPropertyChanged
        {
            private string _state;
    
            public string State
            {
                get
                {
                    return _state;
                }
    
                set
                {
                    if (_state == value) return;
    
                    _state = value;
                    OnPropertyChanged("State");
                }
            }
    
            #region INotifyPropertyChanged Members
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
    
            #endregion
        }
