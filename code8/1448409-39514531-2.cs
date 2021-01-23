 class Program
    {
        static void Main(string[] args)
        {
            Demo demo = new Demo { A = "ABC" };
            Demo demo2;
            OptionOne(demo);
            Console.WriteLine(demo.A); //Outputs World
            demo2 = OptionTwo(demo);
            Console.WriteLine(demo.A); //Outputs Hello
            Console.WriteLine(demo2.A); //Output Hello
            Console.ReadKey();
        }
        private static void OptionOne(Demo demo)
        {
            demo.A = "World";
        }
        private static Demo OptionTwo(Demo demo)
        {
            demo.A = "Hello";
            return demo;
        }
    }
    public class Demo
    {
        public string A { get; set; }
    }</code></pre>
  [1]: https://msdn.microsoft.com/en-us/library/s1ax56ch.aspx
