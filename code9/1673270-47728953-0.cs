    public class Base
    {
        public void DoSomething(IOrderedEnumerable<string> strings)
        {
            Console.WriteLine("Base");
        }
    }
    public class Derived : Base
    {
        public void DoSomething(IOrderedEnumerable<object> objects)
        {
            Console.WriteLine("Derived");
        }
    }
