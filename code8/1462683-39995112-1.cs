    public class A 
    {
        protected string PropA { get; set; }
    }
    
    public class B : A
    {
        public string PropB { get; set; }
    }
    
    public class C
    {
        var classB_instance = new B();
        //You can't access classB_instance.PropA
    }
