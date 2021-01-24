    public interface IBase<T>
    {
        T Value { get; set; }
    }
    public class Class1<T> : IBase<T>
    {
        public T Value { get; set; }
        public void SomeMethod1(T input)
        {
        }
    }
    public class Class2<T> : IBase<T>
    {
        public T Value { get; set; }
        public void SomeMethod2(T input)
        {
        }
    }
    public class BaseClass<T1, T2, T3> 
        where T1 : IBase<int> 
        where T2 : IBase<int?> 
        where T3 : IBase<string>
    {
        public T1 A { get; set; }
        public T2 B { get; set; }
        public T3 C { get; set; }        
        public void SomeMethod3()
        {
            A.Value = 3;
            B.Value = null;
            C.Value = "string";
        }
    }
