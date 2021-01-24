    public class DelegateCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;
        public DelegateCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }
        public virtual bool CanExecute() => _canExecute?.Invoke() ?? true;
        public virtual void Execute() => _execute();
        public void RaiseCanExecuteChanged()
        {
            OnCanExecuteChanged();
        }
        public event EventHandler CanExecuteChanged;
        protected virtual void OnCanExecuteChanged()
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
        bool ICommand.CanExecute(object parameter)
        {
            return this.CanExecute();
        }
        void ICommand.Execute(object parameter)
        {
            this.Execute();
        }
    }
