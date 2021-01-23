    public partial class App : Application
    {
        private static LoadingScreen splashScreen;
        private static ManualResetEvent resetSplash;
        [STAThread]
        private static void Main(string[] args)
        {
            try
            {
                resetSplash = new ManualResetEvent(false);
                var splashThread = new Thread(ShowSplash);
                splashThread.SetApartmentState(ApartmentState.STA);
                splashThread.IsBackground = true;
                splashThread.Name = "My Splash Screen";
                splashThread.Start();
                resetSplash.WaitOne(); //wait here until init is complete
                //Now your initialization is complete so go ahead and show your main screen
                var app = new App();
                app.InitializeComponent();
                app.Run();
            }
            catch (Exception ex)
            {
                //Log it or something else
                throw;
            }
        }
        private static void ShowSplash()
        {
            splashScreen = new LoadingScreen(); 
            splashScreen.Show();
            try
            {
                //this would be your async init code inside the task
                Task.Run(async () => await Initialization()) 
                .ContinueWith(t =>
                    {
                        //log it
                    }, TaskContinuationOptions.OnlyOnFaulted);
        }
        catch (AggregateException ex)
        {
            //log it
        }
        resetSplash.Set();
        Dispatcher.Run();
    }
}
