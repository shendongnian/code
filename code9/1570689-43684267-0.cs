    public class A<T> : IA where T : IBase
    {
        T NestedGeneric;
        public A(T nested)
        {
            NestedGeneric = nested;
        }
        public void BaseMethod1() { }
        public void AMethod() { }
    }
    public class Test1 : A<B<Base>>
    {
        public B<Base> NestedGeneric;
        public Test1(B<Base> nested) : base(nested)
        {
            NestedGeneric = nested;
        }
    }
