    public abstract class TestAbstractClass
    {
      public void Process()
      {
         MethodThatGetsCalledEveryTime();
         doDataProcessing();
      }
      public virtual void doDataProcessing()
      {// can add frequent logic here}
      protected void MethodThatGetsCalledEveryTime()
      {
          // do stuff here
      }
    }
