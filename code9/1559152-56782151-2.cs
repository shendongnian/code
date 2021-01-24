    public partial class App : Application
    {
        KeyboardListener KListener = new KeyboardListener();
    
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            KListener.KeyDown += new RawKeyEventHandler(KListener_KeyDown);
        }
    
        void KListener_KeyDown(object sender, RawKeyEventArgs args)
        {
            Console.WriteLine(args.Key.ToString());
            Console.WriteLine(args.ToString()); // Prints the text of pressed button, takes in account big and small letters. E.g. "Shift+a" => "A"
        }
    
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            KListener.Dispose();
        }
    }
