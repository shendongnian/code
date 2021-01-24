    public class Model : INotifyPropertyChanged
    {
        string _desc;
        public string Desc { get { return _desc; } set { _desc = value; RaisePropertyChanged("Desc"); } }
        string _name;
        public string Name { get { return _name; } set { _name = value; RaisePropertyChanged("Name"); } }
        public event PropertyChangedEventHandler PropertyChanged;
        internal void RaisePropertyChanged(string propname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }
    }
