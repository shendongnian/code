     public static class Extensions
        {
            public delegate void Del();
            public static void Time(this Del action)
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
            }
        }
