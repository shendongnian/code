    public class ViewWrapper : ElementWrapper, INotifyPropertyChanged
    {
        string _viewSubGroup;
        public string ViewSubGroup { get { return _viewSubGroup; } set { _viewSubGroup = value; RaisePropertyChanged("ViewSubGroup"); } } 
        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string propname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }
    }
