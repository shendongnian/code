    class Initiator
    {
        readonly Dictionary<Type, Func<MyBase>> _dict = new Dictionary<Type, Func<MyBase>>();
        
        internal Initiator(InitVal initVal)
        {
            _dict[typeof(A)] = (Func<MyBase>)(() => new A(initVal));
            _dict[typeof(B)] = (Func<MyBase>)(() => new B(initVal));
        }
        
        public T CreateObject<T>() where T : MyBase
        {
            var ctor = _dict[typeof(T)];
            return (T)ctor();
        }
    }
