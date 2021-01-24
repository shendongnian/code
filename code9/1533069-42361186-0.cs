    public class MyString : INotifyPropertyChanged
    {
        public MyString(string value) { Value = value; }
        string _value;
        public string Value { get { return _value; } set { _value = value; RaisePropertyChanged("Value"); } }
        bool _isSelected;
        public bool IsSelected { get { return _isSelected; } set { _isSelected = value; RaisePropertyChanged("IsSelected"); } }
        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string propname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }
    } 
