    class MainViewModel : NotifyPropertyChangedBase
    {
        private ButtonViewModel _button0 = new ButtonViewModel();
        public ButtonViewModel Button0
        {
            get { return _button0; }
            set { _UpdateField(ref _button0, value); }
        }
        private ButtonViewModel _button1 = new ButtonViewModel();
        public ButtonViewModel Button1
        {
            get { return _button1; }
            set { _UpdateField(ref _button1, value); }
        }
        private ButtonViewModel _button2 = new ButtonViewModel();
        public ButtonViewModel Button2
        {
            get { return _button2; }
            set { _UpdateField(ref _button2, value); }
        }
        public ICommand ResetCommand { get; }
        public MainViewModel()
        {
            ResetCommand = new DelegateCommand(_Reset);
            Button0.Color = _CoerceColorString(Settings.Default.Color0);
            Button1.Color = _CoerceColorString(Settings.Default.Color1);
            Button2.Color = _CoerceColorString(Settings.Default.Color2);
            Button0.PropertyChanged += (s, e) =>
            {
                Settings.Default.Color0 = _CoercePropertyValue(Button0.Color);
                Settings.Default.Save();
            };
            Button1.PropertyChanged += (s, e) =>
            {
                Settings.Default.Color1 = _CoercePropertyValue(Button1.Color);
                Settings.Default.Save();
            };
            Button2.PropertyChanged += (s, e) =>
            {
                Settings.Default.Color2 = _CoercePropertyValue(Button2.Color);
                Settings.Default.Save();
            };
        }
        private object _CoerceColorString(string color)
        {
            return !string.IsNullOrWhiteSpace(color) ? color : DependencyProperty.UnsetValue;
        }
        private string _CoercePropertyValue(object color)
        {
            string value = color as string;
            return value ?? "";
        }
        private void _Reset()
        {
            Button0.Reset();
            Button1.Reset();
            Button2.Reset();
        }
    }
