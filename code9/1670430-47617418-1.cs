    public interface IFoo {
         int A { get; set;}
         string B { get; set;}
    }
    
    public interface IBoo : IFoo{
         decimal C { get; set;}
    }
    
    public class Foo: IFoo {...}
    
    public class Boo: IBoo {...}
    
    public class Extended<T> where T : IFoo
    {
    	T Foo { get; set; } // Work with this property
        bool D { get; set;}
    }
