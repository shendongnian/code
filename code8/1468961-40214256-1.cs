    using System;
    using System.Windows.Input;
    
    namespace WpfApplication1
    {
        public abstract class CommandBase : ICommand
        {
    
            public virtual event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }
    
            public virtual bool CanExecute( object parameter )
            {
                return true;
            }
    
            public void Execute( object parameter )
            {
                if ( CanExecute( parameter ) )
                    DoExecute( parameter );
            }
    
            protected abstract void DoExecute( object parameter );
    
        }
    }
