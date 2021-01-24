    public class CheckableItem<T> : INotifyPropertyChanged
    {
        public T Item { get; set; }
        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected == value)
                    return;
                _isSelected = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsSelected)));
            }
        }
        private bool _checked;
        public bool IsChecked
        {
            get => _checked;
            set
            {
                if (_checked == value)
                    return;
                _checked = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsChecked)));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
