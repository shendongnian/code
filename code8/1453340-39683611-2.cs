    class MyViewModel : INotifyPropertyChanged
    {
        private string _text1;
        private string _text2;
        public string Text1
        {
            get { return _text1; }
            set { _UpdateField(ref _text1, value); }
        }
        public string Text2
        {
            get { return _text2; }
            set { _UpdateField(ref _text2, value); }
        }
        public ICommand SwapValues { get; }
        public MyViewModel()
        {
            SwapValues = new SwapValuesCommand(this);
        }
        private class SwapValuesComand : ICommand
        {
            private readonly MyViewModel _owner;
            public SwapValuesCommand(MyViewModel owner)
            {
                _owner = owner;
            }
            public event EventHandler CanExecuteChanged;
            public bool CanExecute(object parameter) { return true; }
            public void Execute(object parameter)
            {
                string temp = _owner.Text1;
                _owner.Text1 = _owner.Text2;
                _owner.Text2 = temp;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void _UpdateField<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.DynamicInvoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
