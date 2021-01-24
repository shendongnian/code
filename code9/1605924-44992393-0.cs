    public interface IA { void Do(); }
    public class A : IA { ... }
    public class B : IA { ... }
    
    A a = null;
    var something = a ?? new B(); 
