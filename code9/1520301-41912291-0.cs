    public enum MenuCommands
    {
        NEXT_PAGE = 0,
        PREVIOUS_PAGE = 1
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
            // switch your viewmodel here
        }
    
    }
