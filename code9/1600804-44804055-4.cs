    public class ViewModel
    {
            public ObservableCollection<string> MyStrings { get; set; }
            public ICommand AddStringCommand { get; private set; }
    
            public ViewModel()
            {
                if (MyStrings == null) MyStrings = new ObservableCollection<string>();
    
                for (int i = 0; i < 5; i++)
                {
                    MyStrings.Add("string " + i);
                }
    
                AddStringCommand = new AddLabelCommand(AddString);
                 
            }
    
            public void AddString()
            {
                MyStrings.Add("string " + (MyStrings.Count));
            }
    
     }
    public class AddLabelCommand : ICommand
    {
            readonly Action _action = null;
    
            public AddLabelCommand(Action commandToExecute)
            {
                _action = commandToExecute; //Handle null condition
            }
    
            public bool CanExecute(object parameter)
            {
                return true;
            }
    
            public event EventHandler CanExecuteChanged;
    
            public void Execute(object parameter)
            {
                _action();
            }
    }   
     
