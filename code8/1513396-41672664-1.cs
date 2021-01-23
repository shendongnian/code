    using Prism.Wpf.Commands; // For easy commands
    using PatientAdminTool.Services; // Where you put your new service
    public class MainWindowViewModel
    {
       private IShowDialogService _ShowDialogService;
       public MainWindowViewModel(IShowDialogService showDialogService)
       {
           _ShowDialogService = showDialogService;
    
           // Or do: _ShowDialogService = new ShowDialogService();
           // But that's not a good practice and won't let you test
           // this ViewModel properly.
           OpenPatientWindowCommand = new DelegateCommand(OnOpenPatientWindowCommandExecute);
       }
       public ICommand OpenPatientWindowCommand { get; private set; }
       private void OnOpenPatientWindowCommandExecute()
       {
           _ShowDialogService.ShowPatientWindow();
       }
    }
