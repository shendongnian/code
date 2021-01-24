     public void MethodA(ICaller caller)
     {
        var class = caller as B;
        if(class!=null)
        ...
     }
    public class ClassC
    {
        Public ClassA objA;
        public void MethodC()
        {
            objA.MethodA(this);   
        }
    }
