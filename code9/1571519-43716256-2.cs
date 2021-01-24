    public interface IA {}
    public class A : IA {}
    
    public class B 
    {
        public IA AInstance { get; set; }
        public B (IA a)
        {
            AInstance = a;
        }
    
        public void test()
        {
            /* do something with `AInstance` */
        }
    }
