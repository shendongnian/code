    public abstract class A
    {
        private A() { }
        
        private static IDictionary<Type, IFactory> factories = new Dictionary<Type, IFactory>
        {
            {typeof(B), new B.BFactory() },
            {typeof(C), new C.CFactory() }
        };
        
        public static T Create<T>() where T : A 
            => factories.TryGetValue(typeof(T), out var factory) ? ((IFactory<T>)factory).Create() : throw new InvalidOperationException();
        private interface IFactory { }
        private interface IFactory<T> : IFactory
        {
            T Create();
        }
        
        public class B : A
        {
            private B() { }
            public class BFactory : IFactory<B>
            {
                B IFactory<B>.Create() => new B();
            }
        }
        
        public class C : A
        {
            private C() { }
            public class CFactory : IFactory<C>
            {
                C IFactory<C>.Create() => new C();
            }
        }
    }
