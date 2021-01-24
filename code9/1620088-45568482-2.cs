    using System.ComponentModel;
    
    namespace RdElectReg
    {
        class Progress : INotifyPropertyChanged
        {
            private string _textstr = "";
    
            public Progress()
            {
                _textstr = "";
            }
    
            public Progress(string text)
            {
                _textstr = text;
            }
    
            public string Textstr
            {
                get
                {
                    return _textstr;
                }
                set
                {
                    _textstr = value;
                    OnPropertyChanged("Textstr");
                }
            }
    
            // property changed event
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void OnPropertyChanged(string PropertyName)
            {
                if (this.PropertyChanged != null)
                {
                    // Raise the PropertyChanged event
                    this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
                }
            }
    
         }
    }
