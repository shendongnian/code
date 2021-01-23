    using System;
    using System.Collections.ObjectModel;
    
    namespace WpfApplication1.ViewModel
    {
        public class MainWindowViewModel : ObservableObject
        {
    
            public MainWindowViewModel()
            {
                AddNewCommand = new CommandViewModel
                {
                    DisplayText = "Add",
                    Command = new RelayCommand( DoAddNewCommand )
                };
    
                Commands = new ObservableCollection<CommandViewModel>();
            }
    
            public CommandViewModel AddNewCommand { get; }
    
            public ObservableCollection<CommandViewModel> Commands { get; }
    
            private void DoAddNewCommand( object obj )
            {
                Commands.Add( new CommandViewModel
                {
                    DisplayText = "Foo",
                    Command = new RelayCommand( DoFoo ),
                } );
            }
    
            private void DoFoo( object obj )
            {
                throw new NotImplementedException();
            }
    
        }
    }
