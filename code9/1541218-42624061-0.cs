    public class Model : INotifyPropertyChanged
    {
        int? _indexNullable;
        public int? IndexNullable { get { return _indexNullable; } set { _indexNullable = value; RaisePropertyChanged("IndexNullable"); } }
        int _index;
        public int Index { get { return _index; } set { _index = value; RaisePropertyChanged("Index"); } }
        public event PropertyChangedEventHandler PropertyChanged;
        internal void RaisePropertyChanged(string propname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }
    }
