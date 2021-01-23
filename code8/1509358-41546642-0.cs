    public class SomeclassFoo : INotifyPropertyChanged
    {
        private IList<string> _somebody;
        public IList<string> Somebody
        {
            get { return _somebody; }
            set { _somebody = value; NotifyPropertyChanged(); }
        }
        private IList<string> _something;
        public IList<string> Something
        {
            get { return _something; }
            set { _something = value; NotifyPropertyChanged(); }
        }
        private IList<string> _someWhere;
        public IList<string> Somewhere
        {
            get { return _someWhere; }
            set { _someWhere = value; NotifyPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
