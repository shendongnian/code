    public class Command : ICommand
    { 
        public Command(Action<object> parameterizedAction, bool canExecute = true)
        {
            _parameterizedAction = parameterizedAction;
            _canExecute = canExecute;
        }
         
        Action<object> _parameterizedAction = null;
        bool _canExecute = false;
        public bool CanExecute
        {
            get { return _canExecute; }
            set
            {
                if (_canExecute != value)
                {
                    _canExecute = value;
                    CanExecuteChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        public event EventHandler CanExecuteChanged;
        bool ICommand.CanExecute(object parameter)
        {
            return _canExecute;
        }
        void ICommand.Execute(object parameter)
        {
            this.DoExecute(parameter);
        }
        public virtual void DoExecute(object param)
        { if (_parameterizedAction != null)
                _parameterizedAction(param);
            else
                throw new Exception();
        }
    }
