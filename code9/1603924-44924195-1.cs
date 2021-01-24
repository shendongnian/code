    public interface IBase {}
    public interface IFirst : IBase { }
    public interface ISecond : IBase { }
    
    public abstract class A<T> {
        public T SomeProperty { get; }
    
        protected A(T someProperty) {
            SomeProperty = someProperty;
        }
    }
    
    public class B : A<IBase> {
        public B(IBase someProperty) : base(someProperty) {
        }
    }
    
    public class C : B {
        public C(ISecond someProperty) : base(someProperty) {
            //Works now
        }
    }
