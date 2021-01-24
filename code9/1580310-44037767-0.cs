     public class BaseViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private string _scratchMessage;
    
            public string ScratchMessage
            {
                get { return _scratchMessage; }
                set
                {
                    _scratchMessage = value;
                    this.OnPropertyChanged("ScratchMessage");
                }
            }
    
            // Create the OnPropertyChanged method to raise the event 
            protected virtual void OnPropertyChanged(string propertyName = null)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
    
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    
        public class ViewModel1 : BaseViewModel
        {
            ViewModel1()
            {
                this.ScratchMessage = "Message";
            }
        }
