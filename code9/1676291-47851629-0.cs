    // Very simple container class
    class ColorViewModel
    {
        public Brush Brush { get; }
        public string Name { get; }
        public ColorViewModel(Brush brush, string name)
        {
            Brush = brush;
            Name = name;
        }
    }
    // Main view model, acts as the data context for the window
    class MainViewModel : INotifyPropertyChanged
    {
        public IReadOnlyList<ColorViewModel> Colors { get; }
        private Brush _selectedColor;
        public Brush SelectedColor
        {
            get { return _selectedColor; }
            set { _UpdateField(ref _selectedColor, value); }
        }
        public MainViewModel()
        {
            Colors = typeof(Colors).GetProperties(BindingFlags.Static | BindingFlags.Public)
                .Select(p => new ColorViewModel(new SolidColorBrush((Color)p.GetValue(null)), p.Name))
                .ToList().AsReadOnly();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void _UpdateField<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
