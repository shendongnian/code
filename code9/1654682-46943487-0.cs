    using System.Windows.Forms;
    // The class that handles the creation of the application windows
    class MyApplicationContext : ApplicationContext {
        private MyApplicationContext() {
            // Handle the ApplicationExit event to know when the application is exiting.
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
            log_watcher = new FileSystemWatcher();
            log_watcher.Path = Path.GetDirectoryName(pathToFile);
            log_watcher.Filter = recent_file.Name;
            log_watcher.NotifyFilter = NotifyFilters.LastWrite;
            log_watcher.Changed += new FileSystemEventHandler(OnChanged);
            log_watcher.EnableRaisingEvents = true;
        }
        public static void OnChanged(object sender, FileSystemEventArgs e) {
            Console.WriteLine("File has changed");
        }
        private void OnApplicationExit(object sender, EventArgs e) {
            Console.WriteLine("File monitor exited.");
        }
        [STAThread]
        static void Main(string[] args) {
        
            // Create the MyApplicationContext, that derives from     ApplicationContext,
            // that manages when the application should exit.
            MyApplicationContext context = new MyApplicationContext();
            // Run the application with the specific context. It will exit when
            // all forms are closed.
            Application.Run(context);
        }
    }
