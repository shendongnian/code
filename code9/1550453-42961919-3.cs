    class Program
    {
        public class MyClass
        {
            public StructTest MyStruct;
        }
        public struct StructTest
        {
            public int Id { get; set; }
            public int OtherId { get; set; }
        }
        private static void Main()
        {
            var c = new MyClass();
            c.MyStruct.Id = 51;
            c.MyStruct.OtherId = 52;
            object boxed = c.MyStruct;
            Console.WriteLine("Attach the debugger now.");
            Console.ReadKey();
            Console.WriteLine(c.MyStruct.Id.ToString() +  boxed);
        }
    }
