    public class CuteInterfaceImplementation<T> : CuteInterfaceImplementation_COMMON<T>
    {
        public CuteInterfaceImplementation(T element) : base(element)
        {
            
        }
    }
    public class CuteInterfaceImplementation_COMMON<T> : IMyCuteInterface<T>
    {
        private readonly T _element;
        public CuteInterfaceImplementation_COMMON(T element)
        {
            _element = element;
        }
        public void DoSomeStuff() { }
        public void DoSomeStuff2() { }
    }
    public class CuteInterfaceImplementation_WITHEnumerable<T> : CuteInterfaceImplementation_COMMON<T>,  IMyCuteInterface_WITHEnumerable<T> where T : IEnumerable
    {
        private readonly T _element;
        public CuteInterfaceImplementation_WITHEnumerable(T element) : base(element)
        {
            _element = element;
        }
        public void DoSomethingOnlyPossibleIfGenericIsIEnumerable() { }
    }
