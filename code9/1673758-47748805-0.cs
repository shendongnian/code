    public class Person : INotifyPropertyChanged
        {
            
            // Declare the event
            public event PropertyChangedEventHandler PropertyChanged;
            private string _name;
            public string Name
            {
                get { return _name; }
                set
                {
                    _name = value;
                    // Call OnPropertyChanged whenever the property is updated
                    OnPropertyChanged("Name");
                }
            }
            // Create the OnPropertyChanged method to raise the event
            protected void OnPropertyChanged(string name)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
