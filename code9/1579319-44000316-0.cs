     public class TestVM : INotifyPropertyChanged
        {
            public TestVM()
            {
                CopyCommand = new RelayCommand<string>(OnCopyExecuted);
            }
    
            private void OnCopyExecuted(string commandParameter)
            {
                TextUpdate = commandParameter;
            }
    
            private string _textUpdate;
    
            public string TextUpdate
            {
                get { return _textUpdate; }
                set
                {
                    if (_textUpdate != value)
                    {
                        _textUpdate = value;
                        OnPropertyChanged();
                    }
                }
            }
    
    
            public RelayCommand<string> CopyCommand { get; private set; }
    
    
            public event PropertyChangedEventHandler PropertyChanged = delegate { };
            public virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
    
        }
