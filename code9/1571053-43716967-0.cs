    public class Item : INotifyPropertyChanged
    {
        private string _title;
        private bool _isSelected;
    
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged("Title");
            }
        }
    
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                RaisePropertyChanged("IsSelected");
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
