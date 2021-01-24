    public class Person : INotifyPropertyChanged
    {
        string _name;
        public string Name { get { return _name; } set { _name = value; RaisePropertyChanged("Name"); } }
        bool _isSentenced;
        public bool IsSentenced { get { return _isSentenced; } set { _isSentenced = value; RaisePropertyChanged("IsSentenced"); } }
        string _sentence;
        public string Sentence { get { return _sentence; } set { _sentence = value; RaisePropertyChanged("Sentence"); } }
        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string propname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        } 
    }
