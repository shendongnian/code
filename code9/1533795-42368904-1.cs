    public abstract class StackTest
    {
      protected abstract IStack Create(int size);
      [TestMethod]
      public void IsEmpty_NoElements()
      {
         var myStack = Create(10);
         var exp = true;
         var act = myStack.IsEmpty;
         Assert.AreEqual(exp, act);
      }
    }
    [TestClass]
    public class StackImp1Fixture : StackTest
    {
      protected override IStack Create(int size)
      {
         return new StackImpl1(size);
      }
    }
    [TestClass]
    public class StackImp2Fixture : StackTest
    {
      protected override IStack Create(int size)
      {
         return new StackImpl2(size);
      }
    }
