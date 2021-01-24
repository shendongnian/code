    class ButtonViewModel : NotifyPropertyChangedBase
    {
        private object _color = DependencyProperty.UnsetValue;
        public object Color
        {
            get { return _color; }
            set { _UpdateField(ref _color, value); }
        }
        public ICommand ToggleCommand { get; }
        public ButtonViewModel()
        {
            ToggleCommand = new DelegateCommand(_Toggle);
        }
        private void _Toggle()
        {
            Color = object.Equals(Color, "Green") ? "Red" : "Green";
        }
        public void Reset()
        {
            Color = DependencyProperty.UnsetValue;
        }
    }
