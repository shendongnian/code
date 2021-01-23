    public class MyModel : INotifyPropertyChanged {
        private decimal _someValue;
        public decimal SomeValue
        {
            get { return _someValue; }
            set
            {
                if (value == _someValue) return;
                _someValue = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
