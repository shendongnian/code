    public class Example
    {
        public Action DoSomething {get; set;}
    }
    
    public class Engine
    {
        public void DoSomething() { Console.WriteLine("bleee"); }
    
        static void Main()
        {
            Example e = new Example();
            Engine eng = new Engine();
    
            e.DoSomething = eng.DoSomething;
        }
    }
