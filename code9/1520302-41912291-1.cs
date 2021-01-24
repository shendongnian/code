    public enum MenuCommands
    {
        NEXT_PAGE = 0,
        PREVIOUS_PAGE = 1
    }
    public class MainMenuVm : ViewModelBase
    {
        public MainMenuVm ( Action<MenuCommands> menuCommand )
        {
            _menuCommands = menuCommand;
        }
        private Action<MenuCommands> _menuCommands;
        /// <summary>
        /// Command binded from MainMenuUserControl.xaml
        /// </summary>
        public ICommand NextPageCommand
        {
            get { return _nextPageCommand ?? ( _nextPageCommand = new DelegateCommand ( NextPage ) ); }
        }
        private ICommand _nextPageCommand;
        private void NextPage ( )
        {
            // lets ask our MainWindowVM to switch the view
            _menuCommands ( MenuCommands.NEXT_PAGE );
        }
    }
    public class MainWindowVm : ViewModelBase
    {
        /* ... */
    
        public MainWindowVm ( )
        {
            CurrentView = new MainMenuVm ( Navigate );
    
        }
    
        private void Navigate ( MenuCommands command )
        {
            // Implement your view switching logic here, like:
            switch ( command )
            {
                case MenuCommands.NEXT_PAGE:
                    // CurrentView = new SomeOtherViewModel ( );
                    break;
                case MenuCommands.PREVIOUS_PAGE:
                    // CurrentView = new SomeOtherViewModel ( );
                    break;
                default:
                    break;
            }
        }
    }
