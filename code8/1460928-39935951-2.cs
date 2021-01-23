    public class MainWindow{
      
        public MainWindow()
        { 
           InitializeComponent(); 
           Worker worker = new Worker(this); 
           worker.run_Worker(); 
        }
    }
    public class Worker
    {
     private MainWindow lthis{get;set;}
     public Worker(MainWindow lthis)
     {
       this.lthis = lthis; 
     }
     public void run_worker(){
        while(lthis != default(MainWindow)){
           DoWork();
           Thread.Sleep(5000);
          
        }
     }
     private void DoWork(){
         Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
              lthis.home.InfoLog.Content = "test";
            }));
      }
    }
    public class Home
    {
       public InfoLog InfoLog {get;set;}
    }
    public class InfoLog
    {
      public string Content {get;set;}
    }
