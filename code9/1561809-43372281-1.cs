    interface IInterface {void execute1(string input);void execute2(int input);}
    
    class SomeClass:IInterface
    {
        public void execute1(string input) => Console.WriteLine($"1 {input}");
        public void execute2(int    input) => Console.WriteLine($"2 {input}");
    }
