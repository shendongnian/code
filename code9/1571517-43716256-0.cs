    public class A { }
    
    public class B 
    {
        public A AInstance { get; set; }
        public B (A a)
        {
            AInstance = a;
        }
    
        public void test()
        {
            /* do something with `AInstance` */
        }
    }
