    public class Datenpunkt : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        public void Notify(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        private bool _isChecked;
        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                Notify("IsChecked");
            }
        }
    }
