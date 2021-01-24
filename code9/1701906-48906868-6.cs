     public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            UserControlViewModel = new UserControlViewModel{ Name = "Hello World" };
        }
        public UserControlViewModel UserControlViewModel { get; }
    }
