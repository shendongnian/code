    public class Foo<T> where T : IComparable
    {
        public void Bar(T value)
        {
            DoSomething(value);
        }
    }
