    using System.Windows.Input;
    
    namespace WpfApplication1.ViewModel
    {
        public class CommandViewModel : ObservableObject
        {
    
            private ICommand command;
            private string displayText;
    
            public ICommand Command
            {
                get { return command; }
                set { SetProperty( ref command, value ); }
            }
    
            public string DisplayText
            {
                get { return displayText; }
                set { SetProperty( ref displayText, value ); }
            }
    
        }
    }
