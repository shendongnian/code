      public partial class Startup {
    
        // WPF App
        private App _app;
    
        [STAThread]
        public static void Main(string[] args) {
          try {
            //Do what you need
            //Check the args
            //Start your setup silent
 
            //start the WPF App if need it
            this._app = new App();
            this._app.InitializeComponent();
            this._app.Run();
          } catch (Exception ex) {
            //Logging ex
          }
        }
