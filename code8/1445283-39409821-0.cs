    public interface IMyClass
    {
        int SomeMethod(int x);
    }
    public class MyClass: IMyClass
    {
        public MyClass(int n)
        {
            _impl = MyClassImpl.Create(n);
        }
        public int SomeMethod(int x)
        {
            return _impl.SomeMethod(x);
        }
        // For test purposes only - see later in this answer.
        public bool ImplementationEquals(MyClass other)
        {
            return ReferenceEquals(_impl, other._impl);
        }
        readonly IMyClass _impl;
    }
    internal class MyClassImpl : IMyClass
    {
        static readonly ConcurrentDictionary<int, IMyClass> _dict = new ConcurrentDictionary<int, IMyClass>();
        readonly int _n;
        MyClassImpl(int n)
        {
            _n = n;
        }
        public static IMyClass Create(int n)
        {
            return _dict.GetOrAdd(n, i => new MyClassImpl(i));
        }
        public int SomeMethod(int x)
        {
            return _n + x;
        }
    }
