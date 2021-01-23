    class Program {
        static void Main(string[] args) {
            List<TimerClass> timerList = new List<TimerClass>();
            timerList.Add(new TimerClass() {ID = 1, Type = "Minute"});
            timerList.Add(new TimerClass() {ID = 2, Type = "Daily"});
            Execute();
        }
    
        //Method to execute all default timers
        static void Execute(){
            foreach(TimerClass x in timerList){
                x.Timer = new System.Timers.Timer();
                x.Timer.AutoReset = false;
                x._exec = new ExecTimer(Save);
                switch(x.Type){
                    case "Minute":
                        x.Timer.Interval = 60000;
                    case "Daily";
                        x.Timer.Interval = 360000;
                }
                x.Timer.Start();
            }
        }
    
        //method for creating record
        public void Save(int id){
            TimerClass i = timerList.Where(x => x.ID === id);
    
            DB.Insert(x.Type, DateTime.Now.ToString());
            Console.WriteLine("Successfuly Saved");
    
            // Re-start the timer
            i.Timer.Start();
        }
    }
    
    
    //delegate for timer execution
    public delegate void ExecTimer(int id);
    //Timer Class
    public class TimerClass{
        public System.Timers.Timer Timer { get; set; }
        public int ID { get; set; }
        public string Type {get; set;}
    
        public ExecTimer _exec;
        public void _timer_Elapsed(object sender, ElapsedEventArgs e){
            _exec(ID);
        }
    }
