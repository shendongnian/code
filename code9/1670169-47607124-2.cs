    using System;
    using System.Diagnostics;
    using System.Windows.Input;
    public class RelayCommand : ICommand
    	{
    		readonly Action<object> _execute;
    		readonly Predicate<object> _canExecute;
    
    		#region Constructors
    
    		/// <summary>
    		/// Creates a new command.
    		/// </summary>
    		/// <param name="execute">The execution logic.</param>
    		/// <param name="canExecute">The execution status logic.</param>
    		public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
    		{
                _execute = execute ?? throw new ArgumentNullException(nameof(execute));
    			_canExecute = canExecute;
    		}
    		#endregion // Constructors
    
    		#region ICommand Members
    		[DebuggerStepThrough]
    		public bool CanExecute(object parameter)
    		{
    			return _canExecute?.Invoke(parameter) ?? true;
    		}
    
    		/// <summary>
    		/// Can execute changed event handler.
    		/// </summary>
    		public event EventHandler CanExecuteChanged
    		{
    			add => CommandManager.RequerySuggested += value;
    		    remove => CommandManager.RequerySuggested -= value;
    		}
    
    		public void Execute(object parameter)
    		{
    			_execute(parameter);
    		}
    		#endregion // ICommand Members
    	}
