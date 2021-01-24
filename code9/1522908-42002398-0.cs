    class SubClass : BaseClass, IInterface
    {
      void IInterface.MyMethod()
      {
        base.MyMethod();
      }
    }
