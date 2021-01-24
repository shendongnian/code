    public class CustomersViewModel
    {
        private readonly MainWindowViewModel _vm;
        public CustomersViewModel(MainWindowViewModel vm)
        {
            _vm = vm;
            NavigationCommand = new DelegateCommand<string>(OnNavigate);
        }
        public DelegateCommand<string> NavigationCommand { get; set; }
        private void OnNavigate(string navPath)
        {
            _vm.CurrentViewModel = new SomeOtherViewModel();
        }
    }
