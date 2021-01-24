    public class Program
    {
    
        private ViewModel _viewModel;
    
        public Program()
        {
            Console.WriteLine("Start");
            _viewModel = new ViewModel();
        }
    
        static void Main(string[] args)
        {
            Program prog = new Program();
            Task t = prog.Print();
            t.Wait();
        }
    
        async void Go()
        {
            await Print();
        }
    
        public async Task Print()
        {
            await Task.Run(() => _viewModel.NewSurveyCommand.Execute(null));
        }
    }
    
    public class ViewModel
    {
        public ViewModel()
        {
            NewSurveyCommand = new Command(() => RunTest());
        }
    
        public ICommand NewSurveyCommand { get; private set; }
    
        public void RunTest()
        {
            Console.WriteLine("Running...");
            Thread.Sleep(1000);
            Console.WriteLine("Test done");
        }
    }
    
    public class Command : ICommand
    {
        private Action _action;
    
        public Command(Action action)
        {
            _action = action;
        }
    
        public event EventHandler CanExecuteChanged;
    
        public bool CanExecute(object parameter)
        {
            return true;
        }
    
        public void Execute(object parameter)
        {
            _action.Invoke();
        }
    }
