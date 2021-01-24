    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            listbox.Items.Add("asdf");
            listbox.Items.Add("fdsfsadf");
            listbox.Items.Add("dfsd");
            listbox.Items.Add("a sdfas");
            listbox.Items.Add("asdgas g");
            
            //This is the command that gets executed.
            OnClickCommand = new ActionCommand(x => listbox.Items.Remove(x));
        }
        public ICommand OnClickCommand { get; set; }
    }
    //This implementation of ICommand executes an action.
    public class ActionCommand : ICommand
    {
        private readonly Action<object> Action;
        private readonly Predicate<object> Predicate;
        public ActionCommand(Action<object> action) : this(action, x => true)
        {
        }
        public ActionCommand(Action<object> action, Predicate<object> predicate)
        {
            Action = action;
            Predicate = predicate;
        }
        
        public bool CanExecute(object parameter)
        {
            return Predicate(parameter);
        }
        public void Execute(object parameter)
        {
            Action(parameter);
        }
        
        //These lines are here to tie into WPF-s Can execute changed pipeline. Don't worry about it.
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
    }
