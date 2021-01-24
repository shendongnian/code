    abstract class B
    {
        abstract protected string GetString(); //Notice no implementation
        public void DoSomethingWithGetString()
        {
            Console.WriteLine(GetString());
        }
    }
