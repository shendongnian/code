    static BackgroundWorker looper = new BackgroundWorker();
    static bool isRunning = true;//you can set this to false when closing
    public static void initialize(){
        looper.DoWork+= doLoop;
        looper.RunRunWorkerAsync();
        }
        private static void doLoop(object sender, DoWorkEventArgs e){
            while(isRunning){
               //do looping code
               System.Threading.Thread.Sleep(5000);
                   if(!isRunning)
                       break;
            }
        }
