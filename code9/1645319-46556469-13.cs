    public class MethodA : IMethod
    {
        public int MethodSequence => 1;
        public void RunMethod()
        {
            Console.WriteLine("Ran job A");
        }
    }
    public class MethodB : IMethod
    {
        public int MethodSequence => 2;
        public void RunMethod()
        {
            Console.WriteLine("Ran job B");
        }
    }
    public class MethodC : IMethod
    {
        public int MethodSequence => 3;
        public void RunMethod()
        {
            Console.WriteLine("Ran job C");
        }
    }
