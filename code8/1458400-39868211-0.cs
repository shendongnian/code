    public class LastPageViewModel : WizardPageViewModelBase, IWizardPageLoadableViewModel
    {
        public LastPageViewModel()
        {
            Header = "Last Page";
            Subtitle = "This is a test project for Mahapps and Avalon.Wizard";
    
            InitializeCommand = new RelayCommand<object>(ExecuteInitialize);
            LoadedCommand = new RelayCommand<object>(ExecuteLoaded);
        }
    
        public ICommand LoadedCommand { get; set; }
    
        private async void ExecuteInitialize(object parameter)
        {
            // The Xaml is not created here! so you can't use the DialogCoordinator here.
        }
    
        private async void ExecuteLoaded(object parameter)
        {
            var dialog = DialogCoordinator.Instance;
            var settings = new MetroDialogSettings()
            {
                ColorScheme = MetroDialogColorScheme.Accented
            };
            await dialog.ShowMessageAsync(this, "Hello World", "This dialog is triggered from Avalon.Wizard LoadedCommand", MessageDialogStyle.Affirmative, settings);
        }
    }
