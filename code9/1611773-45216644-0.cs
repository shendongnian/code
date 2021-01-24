    public class ViewModelBase()
        : INotifyPropertyChanged
    {      
        public event PropertyChangedEventHandler PropertyChanged;  
    
        private void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
