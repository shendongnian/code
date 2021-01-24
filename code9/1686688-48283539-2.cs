    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    namespace VM.Commands
    {
    public class TestCommand : ICommand
    {
        private Action<object> _execute;
        private Predicate<object> _canExecute;
        public TestCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        #region Implementation of ICommand
        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }
        public void Execute(object parameter)
        {
            _execute?.Invoke(parameter);
        }
        public event EventHandler CanExecuteChanged;
        #endregion
    }
    }  
