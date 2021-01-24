    public class ViewModel : INotifyPropertyChanged
    {
        // Implementing INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName);
        }        
        // In the setter of property raise event to inform view about changes
        private Boolean _state = true;
        public Boolean State
        {
            get 
            { 
                return _state; 
            }
            set 
            { 
                _state = value;
                RaisePropertyChanged();
            }
        }
    }
