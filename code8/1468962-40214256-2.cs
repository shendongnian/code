    using System;
    
    namespace WpfApplication1
    {
        public class RelayCommand : CommandBase
        {
    
            private readonly Func<object, bool> _canexecute;
            private readonly Action<object> _execute;
    
            public RelayCommand( Action<object> execute ) : this( execute, o => true )
            {
            }
    
            public RelayCommand( Action<object> execute, Func<object, bool> canexecute )
            {
                if ( execute == null ) throw new ArgumentNullException( nameof( execute ) );
                if ( canexecute == null ) throw new ArgumentNullException( nameof( canexecute ) );
    
                _execute = execute;
                _canexecute = canexecute;
            }
    
            public override bool CanExecute( object parameter )
            {
                return base.CanExecute( parameter ) && _canexecute( parameter );
            }
    
            protected override void DoExecute( object parameter )
            {
                _execute( parameter );
            }
    
        }
    }
