    class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void _UpdateField<T>(ref T field, T newValue,
            Action<T> onChangedCallback = null,
            [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, newValue))
            {
                return;
            }
            T oldValue = field;
            field = newValue;
            onChangedCallback?.Invoke(oldValue);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    class DelegateCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;
        public DelegateCommand(Action execute) : this(execute, null) { }
        public DelegateCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke() ?? true;
        }
        public void Execute(object parameter)
        {
            _execute();
        }
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
