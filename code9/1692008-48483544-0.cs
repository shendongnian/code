    class Program
    {
        interface IIntOperation
        {
            int Execute(int a, int b);
        }
        class AddOperation : IIntOperation
        {
            public int Execute(int a, int b) => a + b;
        }
        class SubtractOperation : IIntOperation
        {
            public int Execute(int a, int b) => a - b;
        }
        static void Main(string[] args)
        {
            var lst = new List<IIntOperation>()
            {
                new AddOperation(),
                new SubtractOperation()
            };
            foreach(var op in lst)
            {
                op.Execute(1, 2);
            }
        
        }
    }
