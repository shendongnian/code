    class Program
    {
        static void Main(string[] args)
        {
            int x = 1;
            int y = 2;
            var b = new MyCustomList<B>();
            b.Foo(v => v.P == x, n => n.P = y);
        }
    }
    public static class Extensions
    {
        public static void Foo<T>(this IFoo<T> @this, Func<T, bool> predicate, Action<T> action) => @this.Where(predicate).ToList().ForEach(action);
    }
    public interface IFoo<T> : IList<T>  { }
    class MyCustomList<T> : List<T>, IFoo<T>  { }
    class B
    {
        public int P { get; set; }
    }
