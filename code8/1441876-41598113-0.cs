    public class MyViewModel
    {
        static MyViewModel()
        {
            Instance = new MyViewModel();
        }
        public static MyViewModel Instance { get; }
        private MyViewModel()
        {
            // TODO
        }
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            await Task.CompletedTask;
        }
    }
