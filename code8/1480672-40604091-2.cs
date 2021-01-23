    /// <summary>
    /// https://gist.github.com/schuster-rainer/2648922 
    /// Implementation from Josh Smith of the RelayCommand
    /// </summary>
    public class RelayCommand : ICommand
    {
    	#region Fields
    
    	readonly Predicate<object> _canExecute;
    	readonly Action<object> _execute;
    	#endregion // Fields
    
    	#region Constructors
    
    	/// <summary>
    	/// Initializes a new instance of the <see cref="RelayCommand"/> class.
    	/// </summary>
    	/// <param name="execute">The execute.</param>
    	public RelayCommand(Action<object> execute)
    		: this(execute, null)
    	{
    	}
    
    	/// <summary>
    	/// Initializes a new instance of the <see cref="RelayCommand"/> class.
    	/// </summary>
    	/// <param name="execute">The execute.</param>
    	/// <param name="canExecute">The can execute.</param>
    	/// <exception cref="System.ArgumentNullException">execute</exception>
    	public RelayCommand(Action<object> execute, Predicate<object> canExecute)
    	{
    		if (execute == null)
    			throw new ArgumentNullException("execute");
    
    		_execute = execute;
    		_canExecute = canExecute;
    	}
    	#endregion // Constructors
    
    	#region ICommand Members
    
    
    	/// <summary>
    	/// Occurs when changes occur that affect whether or not the command should execute.
    	/// </summary>
    	public event EventHandler CanExecuteChanged
    	{
    		add { CommandManager.RequerySuggested += value; }
    		remove { CommandManager.RequerySuggested -= value; }
    	}
    
    	/// <summary>
    	/// Defines the method that determines whether the command can execute in its current state.
    	/// </summary>
    	/// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
    	/// <returns>true if this command can be executed; otherwise, false.</returns>
    	public bool CanExecute(object parameter)
    	{
    		return _canExecute == null ? true : _canExecute(parameter);
    	}
    	/// <summary>
    	/// Defines the method to be called when the command is invoked.
    	/// </summary>
    	/// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
    	public void Execute(object parameter)
    	{
    		_execute(parameter);
    	}
    
    	#endregion // ICommand Members
    }
