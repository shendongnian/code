     public partial class App
    {
        public App()
        {
            this.Dispatcher.UnhandledException += OnDispatcherUnhandledException;
        }
        private async void OnDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            await ErrorService.HandleError(e.Exception, "An unhandled exception occurred", true, true);
            e.Handled = true;
        }
    }
