    class Program
    {
        public struct StructTest
        {
            public long Id { get; set; }
            public long OtherId { get; set; }
            public long MoreSpace { get; set; }
            public long EvenMoreSpace { get; set; }
            public long MoreThan64Byte { get; set; }
        }
        private static void Main()
        {
            var c = new StructTest();
            c.Id = 51;
            c.OtherId = 52;
            c.MoreSpace = 53;
            c.EvenMoreSpace = 54;
            c.MoreThan64Byte = 55;
            Console.WriteLine("Attach the debugger now.");
            Console.ReadKey();
            Console.WriteLine(c.Id + c.OtherId + c.MoreSpace + c.EvenMoreSpace);
        }
    }
