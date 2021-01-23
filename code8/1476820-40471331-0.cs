    public class StartCondition
    {
        public int index { get; set; }
        public string device { get; set; }
        public string state { get; set; }
        public bool isPass { get; set; }
    
       // This is the constructor - notice the method name is the same as your class name
       public StartCondition(){
          // initialize everything here
          index = 0;
          device = "unknown";
          state = "disconnected";
          isPass = false;
      }
    }
