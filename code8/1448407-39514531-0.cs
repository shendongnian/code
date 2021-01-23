  class Program
    {
        static void Main(string[] args)
        {
            Action<Demo> action = d =>
            {
                d.A = "World";
            };
            Func<Demo, Demo> func = d =>
            {
                d.A = "hello";
                return d;
            };
            Demo demo = new Demo { A = "ABC" };
            Demo demo2;
            action(demo);
            Console.WriteLine(demo.A); //Outputs World
            demo2 = func(demo);
            Console.WriteLine(demo.A); //Outputs Hello
            Console.WriteLine(demo2.A); //Output  World
            Console.ReadKey();
        }
    }
    public class Demo 
    {
        public string A { get; set; }
    }
