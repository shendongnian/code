    public class RelayCommand : ICommand
        {
            private Action _executeMethod;
            private Func<bool> _canExecuteMethod;
    
            #region RelayCommand ctor
    
            public RelayCommand(Action executeMethod)
            {
                _executeMethod = executeMethod;
            }
    
            public RelayCommand(Action executeMethod, Func<bool> canExecuteMethod)
            {
                _executeMethod = executeMethod;
                _canExecuteMethod = canExecuteMethod;
            }
    
            #endregion
    
            public void RaiseCanExecuteChanged()
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
    
    
            #region ICommand Members
    
            bool ICommand.CanExecute(object parameter)
            {
                if (_canExecuteMethod != null)
                    return _canExecuteMethod();
                if (_executeMethod != null)
                    return true;
                return false;
            }
    
            void ICommand.Execute(object parameter)
            {
                if (_executeMethod != null)
                    _executeMethod();
            }
    
            public event EventHandler CanExecuteChanged = delegate { };
    
            #endregion
        }
    
        //--------------------------------------------------------------------------------------------
    
        public class RelayCommand<T> : ICommand
        {
            private Action<T> _executeMethod;
            private Func<T, bool> _canExecuteMethod;
    
            #region RelayCommand ctor
    
            public RelayCommand(Action<T> executeMethod)
            {
                _executeMethod = executeMethod;
            }
    
            public RelayCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
            {
                _executeMethod = executeMethod;
                _canExecuteMethod = canExecuteMethod;
            }
    
            #endregion
    
            public void RaiseCanExecuteChanged()
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
    
    
            #region ICommand Members
    
            bool ICommand.CanExecute(object parameter)
            {
                var Tparam = (T)parameter;
                if (_canExecuteMethod != null)
                    return _canExecuteMethod(Tparam);
                if (_executeMethod != null)
                    return true;
                return false;
            }
    
            void ICommand.Execute(object parameter)
            {
                if (_executeMethod != null)
                    _executeMethod((T)parameter);
            }
    
            public event EventHandler CanExecuteChanged = delegate { };
    
            #endregion
        }
