    public class Person:INotifyPropertyChanged{
     private string _firstName;
            private string _copyName=string.Empty;
           
            public Person()
            {
                _firstName = "Ronaldo";
                submitCommand = new RelayCommand(MyMethod, canExecuteMethod);
            }
         
            public string FirstName
            {
                get
                {
    
                    return _firstName;
                }
                set
                {
                    _firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
            public string CopyName
            {
                get
                {
    
                    return _copyName;
                }
                set
                {
                    if (_copyName != value)
                    {
                        _copyName = value;
                        OnPropertyChanged("CopyName");
                    }
                }
            }
            public ICommand submitCommand { get; set; }
    
    
    
            private void MyMethod(object param)
            {
                MessageBox.Show("Welcome to Command Demo...");
                CopyName = FirstName;
            }
            private bool canExecuteMethod(object parameter)
            {
                return true;
            }
    
     public event PropertyChangedEventHandler PropertyChanged;
     protected void OnPropertyChanged(params string[] propertyNames)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
    
                if (handler != null)
                {
                    foreach (string propertyName in propertyNames) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                    handler(this, new PropertyChangedEventArgs("HasError"));
                }
            }
    
    }
