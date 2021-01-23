        public class ButtonModel : INotifyPropertyChanged
    {
        private bool _isCurrentTarget;
        private bool _isReached;
        public event PropertyChangedEventHandler PropertyChanged;
        public int ButtonNumber { get; set; }
        public bool IsCurrentTarget
        {
            get { return _isCurrentTarget; }
            set { _isCurrentTarget = value; OnPropertyChanged(); }
        }
        public bool IsReached
        {
            get { return _isReached; }
            set { _isReached = value; OnPropertyChanged(); }
        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
