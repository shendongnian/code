    public class Child1 : IParent
    {
        public void DoSomething()
        {
            Console.WriteLine("Child1.DoSomething");
        }
        public void DoSomethingElse()
        {
            Console.WriteLine("Child1.DoSomethingElse");
        }
    }
    public class Child2 : Child1, IGrandparent
    {
        // Child2 re-implements IGrandparent
        // using explicit interface implementation
        void IGrandparent.DoSomething()
        {
            Console.WriteLine("Child2.DoSomething");
        }
    }
