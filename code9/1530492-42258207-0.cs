    public class MyGroup : INotifyPropertyChanged
    {
        public MyGroup(string _header)
        {
            header = _header;
        }
        protected string header = "";
        public string Header
        {
            get { return header; }
        }
        protected List<MyGroupItem> item = new List<MyGroupItem>();
        public List<MyGroupItem> Item
        {
            get { return item; }
        }
        private MyGroupItem _item;
        public MyGroupItem SelectedItem
        {
            get { return _item; }
            set { _item = value; NotifyPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
