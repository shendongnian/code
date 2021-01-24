    class StartPageViewModel : BaseViewModel
    {
        private MainWindowViewModel mainWindow;
        public ICommand CommandDoBeforeSecondView { get; set; }
    
        public StartPageViewModel(MainWindowViewModel _mainWindow)
        {
            mainWindow = _mainWindow;
            CommandDoBeforeSecondView = new RelayCommand(openSecondView);
        }
    
        private void openSecondView(object obj)
        {
            Console.WriteLine("DO SOME CODE");
            mainWindow.SelectedViewModel = new SecondPageViewModel();
    
        }
    }
