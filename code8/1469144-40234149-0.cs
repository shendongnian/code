    public class TestClass : INotifyPropertyChanged
    { 
        public string Text { get; set; }
        private int _val1 { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public int Val1
        {
            get { return _val1; }
            set
            {
                _val1 = value;
                RaisePropertyChanged("Val1");
            }
        }
        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
