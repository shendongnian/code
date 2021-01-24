    public class ViewModel : ReactiveObject {
        public ICompositeSourceList<A> aList {get;}
    }
    
    public class A : ReactiveObject {
        public ICompositeSourceList<B> bList {get;}
    }
    
    public class B : ReactiveObject {
        //some properties
    }
