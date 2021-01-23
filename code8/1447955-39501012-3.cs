     public static class Extensions
        {
            public delegate void Del();
            public delegate void Del2();
            public static void Time(this Del action)
            {
                // Logic to time the action
                action();
            }
            public static void Time(this Del2 action)
            {
               // Logic to time the action
               action();
            }
    
            public static void Time(this Action action)
            {
                // Logic to time the action
                action();
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {            
                
                ((Extensions.Del)(() => { })).Time();
                ((Extensions.Del2)(() => { })).Time();
                ((Action)(() => { })).Time();
            }        
        }
