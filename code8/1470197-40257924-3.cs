    public partial class App : Application
    {
        public App()
        {
            MainWindowVM mainWindowVM = new MainWindowVM();
            mainWindowVM.Closed += Mwvm_Close;
        }
        private void Mwvm_Close()
        {
            this.Shutdown();
        }
    }
