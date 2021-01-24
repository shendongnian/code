    public class exampleProperties: INotifyPropertyChanged
    {
        //this is the event you have to emit
        public event PropertyChangedEventHandler PropertyChanged;
        //This is a convenience function to trigger the event.
        //The CallerMemberName part will automatically figure out 
        //the name of the property you called from if propertyName == ""
        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName);
            }
        }
        //Any time this property is set it will trigger the event
        private string _currentState = "";
        public string currentState
        {
            get { return _currentState; }
            set
            {
                if (_currentState != value)
                {
                    _currentState = value;
                    OnPropertyChanged();
                }
            }
        }
    }
