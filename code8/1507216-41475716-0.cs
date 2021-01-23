    public class A : IA {
    
    }
    
    
    public interface IA {
    
    }
    List<A> l = new List<A> { new A(), new A(), new A() };
    IEnumerable<IA> ias = l.Cast<IA>();
    IEnumerable<A> aTypes = ias.Cast<A>();
