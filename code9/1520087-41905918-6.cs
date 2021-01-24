    public class ClassA
    {
        public virtual void DoSomething()
        {
            Console.WriteLine("Hello");
        }
    }
    public class ClassB : ClassA
    {
        public override void DoSomething()
        {
            base.DoSomething();
            Console.WriteLine(" World!");
        }
    }
    ClassA a = null;
