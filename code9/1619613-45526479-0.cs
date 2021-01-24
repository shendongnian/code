    public abstract class Base<T> where T : Base<T>
    {
        private static readonly IDictionary<Type, Environment> _Environments = new Dictionary<Type, Environment>();
        public static void Init(Environment NewEnvironment)
        {
            _Environments[typeof(T)] = NewEnvironment;
        }
        protected Environment GetEnvironment()
        {
            if (!_Environments.ContainsKey(typeof(T)))
                return default(Environment);
            return _Environments[typeof(T)];
        }
    }
    public class A : Base<A> {
       // ...
    }
    public class B : Base<B> {
        // ...
    }
