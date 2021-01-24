    public class MyFile : INotifyPropertyChanged
    {
        public void SetPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public string Path { get; set; }
        public int Size { get; set; }
        private bool _checked = false;
        public bool Checked
        {
            get {return _checked;}
            set
                {
                   _checked = value;
                   SetPropertyChanged("Checked");
        }
    }
