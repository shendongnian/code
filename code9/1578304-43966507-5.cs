    public interface IRelayCommand : ICommand
    {
        void RaiseCanExecuteChanged();
    }
    class RelayCommand : IRelayCommand
    {
        private Action _Execute;
        private Func<bool> _CanExecute;
        public event EventHandler CanExecuteChanged;
        public RelayCommand(Action Execute) : this(Execute, null)
        {
        }
        public RelayCommand(Action Execute, Func<bool> CanExecute)
        {
            if (Execute == null)
                throw new ArgumentNullException();
            _Execute = Execute;
            _CanExecute = CanExecute;
        }
        public bool CanExecute(object parameter)
        {
            return (_CanExecute == null) ? true : _CanExecute();
        }
        public void Execute(object parameter)
        {
            _Execute();
        }
        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
