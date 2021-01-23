    public class MyMainWindow
    {
        private IDialogService dialogService;
    
        public MyMainWindow(IUnityContainer container)
        {
            dialogService = container.Resolve<IDialogService>();
        }
    
        private void ExecuteOpenChildWindowCommand(object context)
        {
            var dlg = _dialogService.Show<IMyDialogWindow>();
        }
    }
