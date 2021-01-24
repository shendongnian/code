    public class Course : INotifyPropertyChanged
    {
        private int _amountLesson;
        public int AmountLesson
        {
            get { return _amountLesson; }
            set
            {
                _amountLesson = value;
                OnPropertyChanged("AmountLesson");
            }
        }
        //...
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
