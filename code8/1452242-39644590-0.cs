    public class Killer
    {
        protected const int timerInterval = 1000; // define here interval between ticks
    
        protected Timer timer = new Timer(timerInterval); // creating timer
    
        public Killer()
        {
            timer.Elapsed += Timer_Elapsed;     
        }
    
        public void Start()
        {
            timer.Start();
        }
    
        public void Stop()
        {
            timer.Stop();
        }
    
        public void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {  
            try
            {
                System.Diagnostics.Process[] myProcs = System.Diagnostics.Process.GetProcessesByName("mmc");
                myProcs[0].Kill();
            }
            catch {}
        }
    }
    
    ...
    
    public static void Main(string[] args)
    {   
        Killer killer = new Killer();
        Thread consoleInput = new Thread(_consoleInput);
        _consoleInput.Start();
        killer.Start();
        
        ...
    
        // whenever you want you may stop your killer
        killer.Stop();
    }
