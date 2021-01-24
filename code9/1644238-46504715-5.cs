    public class CommonState : INotifyPropertyChanged
    {
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    
        private bool _isChecked;
    
        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                if (value != _isChecked)
                {
                    _isChecked = value;
                    OnPropertyChanged();
                }
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    }
