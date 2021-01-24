    class ButtonViewModel : NotifyPropertyChangedBase
    {
        public int ButtonIndex { get; }
        private string _color;
        public string Color
        {
            get { return _color; }
            set { _UpdateField(ref _color, value); }
        }
        public ICommand ToggleCommand { get; }
        public ButtonViewModel(int buttonIndex)
        {
            ButtonIndex = buttonIndex;
            ToggleCommand = new DelegateCommand(_Toggle);
        }
        private void _Toggle()
        {
            Color = Color == "Green" ? "Red" : "Green";
        }
        public void Reset()
        {
            Color = null;
        }
    }
