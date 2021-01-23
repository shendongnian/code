    public class Form1
    {
        // ...
    
        public static readonly Form1 Instance {get; private set};
    
        public Form1()
        {
            Instance = this;
        }
    
        // ...
    }
