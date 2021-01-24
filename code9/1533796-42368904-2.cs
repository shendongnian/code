    public class GenStackTest<TStack> where TStack : IStack, new()
    {
      
      [TestMethod]
      public void IsEmpty_NoElements()
      {
         var myStack = new TStack();
         var exp = true;
         var act = myStack.IsEmpty;
         Assert.AreEqual(exp, act);
      }
    }
    [TestClass]
    public class GenStack1Fixture : GenStackTest<StackImpl1>
    {
    }
    [TestClass]
    public class GenStack2Fixture : GenStackTest<StackImpl2>
    {
    }
