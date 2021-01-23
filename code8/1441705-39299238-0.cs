    class ViewModel : INotifyPropertyChanged
    {
        private bool _hasItems;
        public bool HasItems
        {
            get { return _hasItems; }
            set { _UpdateValue(ref _hasItems, value); }
        }
        public ObservableCollection<string> Items { get; } = new ObservableCollection<string>();
        public event PropertyChangedEventHandler PropertyChanged;
        private void _UpdateValue<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!object.Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.DynamicInvoke(this, new PropertyChangedEventArgs(propertyName));
                if (propertyName == nameof(HasItems))
                {
                    if (HasItems)
                    {
                        Items.Add("test item");
                    }
                    else
                    {
                        Items.Clear();
                    }
                }
            }
        }
    }
