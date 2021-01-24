    public interface IBase<T>
    {
    }
    
    public class Class1<T> : IBase<T>
    {
    }
    
    public class Class2<T> : IBase<T>
    {
    }
    
    public class BaseClass<T1, T2, T3, T11, T22, T33> 
        where T1 : IBase<T11> 
        where T2 : IBase<T22> 
        where T3 : IBase<T33>
    {
        T1 A { get; set; }
        T2 B { get; set; }
        T3 C { get; set; }        
    }
