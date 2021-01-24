    class Parent
    {
        protected string foo;
        public Parent()
        {
            foo = "Parent1";
            DoSomething();
            foo = "Parent2";
        }
        protected virtual void DoSomething()
        {
            Console.WriteLine("Parent Method");
        }
    }
    class Child : Parent
    {
        public Child()
        {
            foo = "HELLO";
        }
        protected override void DoSomething()
        {
            Console.WriteLine(foo.ToLower());
        }
    }
    class SecondChild : Parent
    {
        public SecondChild()
        {
            var c = new Child();
        }
        protected override void DoSomething()
        {
            Console.WriteLine("In second Child");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SecondChild c = new SecondChild();
            Console.ReadLine();
        }
    }
