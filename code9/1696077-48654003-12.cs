    public class SomethingDifferent
    {
         private readonly IAbstraction _inner;
         public SomethingDifferent(IAbstraction inner)
         {
             _inner = inner;
         }
         public string DoMyOwnThing(int example)
         {
             return _inner.method1 + " ExtraInfo";
         }
    }
