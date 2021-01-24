    public class SE<T> : ISE<T> { }
    public class SomeClassA { }
    public class ConcreteSE_A : ISE<SomeClass_A>, IConcreteSE_A { }
    
    public interface IConcreteSE_A : ISE<SomeClass_A> { }
    
    kernel.Bind(typeof(ISE<>)).To(typeof(SE<>));
    kernel.Bind<IConcreteSE_A>().To<ConcreteSE_A>();
