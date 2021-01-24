    public abstract class BaseClass<T>
    {
    }
    
    public abstract class Derived<T1, T2, T3>
        where T1 : BaseClass<int> 
        where T2 : BaseClass<int?> 
        where T3 : BaseClass<string>
    {
        T1 A { get; set; }
        T2 B { get; set; }
        T3 C { get; set; }
    }
