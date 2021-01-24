    public class SomethingDifferent : IAbstraction
    {
         private readonly IAbstraction _inner;
         public SomethingDifferent(IAbstraction inner)
         {
             _inner = inner;
         }
         public string method1(int example)
         {
             return _inner.method1 + " ExtraInfo";
         }
    }
