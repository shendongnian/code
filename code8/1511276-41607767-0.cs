    internal static class Program
    {
        public static bool isButtonClicked= false;
    
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
    
            SplashScreen.ShowSplashScreen();
            Application.DoEvents();
    
            while (!isButtonClicked)
            {
                System.Threading.Thread.Sleep(50);
            }
    
            var window = new MyForm();
            window.Load += (s, e) => 
            {        
                 SplashScreen.CloseForm();
                 window.Activate();
            }
            Application.Run(window);
            
        }
    }
