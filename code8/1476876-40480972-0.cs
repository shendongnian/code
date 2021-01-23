    public class Students : INotifyPropertyChanged {
        private bool _selected;
        public bool Selected {
            get { return _selected; }
            set {
                if (value == _selected) return;
                _selected = value;
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
