    public class Class1:INotifyPropertyChanged
    {
        private bool _isCheckedIn;
        public bool IsCheckedIn {
            get { return _isCheckedIn; }
            set {
                if (value == _isCheckedIn) return;
                _isCheckedIn = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
