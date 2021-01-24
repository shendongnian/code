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
    
    public class BaseClass<T1, T2, T3, T11, T22, T33> 
        where T1 : IBase<T11> 
        where T2 : IBase<T22> 
        where T3 : IBase<T33>
    {
        public T1 A { get; set; }
        public T2 B { get; set; }
        public T3 C { get; set; }        
    }
