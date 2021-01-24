    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Input;
    
    namespace WpfApplication8
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
        }
    
        public class MainWindowViewModel : INotifyPropertyChanged
        {
            private ICommand command1;
            public ICommand Command1 { get { return command1; } set { command1 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Command1))); } }
    
            private string myData;
            public string MyData { get { return myData; } set { myData = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MyData))); } }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public MainWindowViewModel()
            {
                Command1 = new RelayCommand<object>(Command1Execute, Command1CanExecute);
            }
    
            private bool Command1CanExecute(object obj)
            {
                // Only allow execute if MyData has data
                return !string.IsNullOrWhiteSpace(MyData);
            }
    
            private void Command1Execute(object obj)
            {
                MessageBox.Show($"CommandParameter = '{obj}'");
            }
        }
    
        public class RelayCommand<T> : ICommand
        {
            #region Fields
    
            readonly Action<T> _execute = null;
            readonly Predicate<T> _canExecute = null;
    
            #endregion
    
            #region Constructors
    
            /// <summary>
            /// Initializes a new instance of <see cref="DelegateCommand{T}"/>.
            /// </summary>
            /// <param name="execute">Delegate to execute when Execute is called on the command.  This can be null to just hook up a CanExecute delegate.</param>
            /// <remarks><seealso cref="CanExecute"/> will always return true.</remarks>
            public RelayCommand(Action<T> execute)
                : this(execute, null)
            {
            }
    
            /// <summary>
            /// Creates a new command.
            /// </summary>
            /// <param name="execute">The execution logic.</param>
            /// <param name="canExecute">The execution status logic.</param>
            public RelayCommand(Action<T> execute, Predicate<T> canExecute)
            {
                if (execute == null)
                    throw new ArgumentNullException("execute");
    
                _execute = execute;
                _canExecute = canExecute;
            }
    
            #endregion
    
            #region ICommand Members
    
            ///<summary>
            ///Defines the method that determines whether the command can execute in its current state.
            ///</summary>
            ///<param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
            ///<returns>
            ///true if this command can be executed; otherwise, false.
            ///</returns>
            public bool CanExecute(object parameter)
            {
                return _canExecute == null ? true : _canExecute((T)parameter);
            }
    
            ///<summary>
            ///Occurs when changes occur that affect whether or not the command should execute.
            ///</summary>
            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }
    
            ///<summary>
            ///Defines the method to be called when the command is invoked.
            ///</summary>
            ///<param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
            public void Execute(object parameter)
            {
                _execute((T)parameter);
            }
    
            #endregion
        }
    }
