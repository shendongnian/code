    public class Person : INotifyPropertyChanged
    {
        MyTypes _thetype;
        public MyTypes TheType { get { return _thetype; } set { _thetype = value; RaisePropertyChanged("TheType"); } }
        string _name;
        public string Name { get { return _name; } set { _name = value; RaisePropertyChanged("Name"); } }
          
        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string propname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }
    }
