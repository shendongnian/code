    public class X
    {
       public X(IHelper helper)
       {
            Helper = helper;
       }
    
       private IHelper Helper { get; }
        
       public void DoStuff() 
       {
            var result = Helper.DoOtherStuff(input);
       }
    }
