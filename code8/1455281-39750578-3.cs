    using System;
    using System.Windows.Input;
    namespace HollowEarth.MVVM
    {
        public class DelegateCommand : ICommand
        {
            private readonly Predicate<object> _canExecute;
            private readonly Action<object> _execute;
            public event EventHandler CanExecuteChanged;
            #region Constructors
            public DelegateCommand(Action<object> execute)
                : this(execute, null)
            {
            }
            public DelegateCommand(Action execute)
                : this(o => execute(), null)
            {
            }
            public DelegateCommand(Action execute, Func<bool> canExecute)
            {
                _execute = o => execute();
                _canExecute = o => canExecute();
            }
            public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
            {
                _execute = execute;
                _canExecute = canExecute;
            }
            #endregion Constructors
            public virtual bool CanExecute(object parameter)
            {
                if (_canExecute == null)
                {
                    return true;
                }
                return _canExecute(parameter);
            }
            public virtual void Execute(object parameter)
            {
                _execute(parameter);
            }
            public void RaiseCanExecuteChanged()
            {
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
