    public class obj : INotifyPropertyChanged 
    {
        public event PropertyChanged;
        private int _count;
        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Count"));
            }
        }
    }
