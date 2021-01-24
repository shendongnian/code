    [TestClass]
    public class PlaceholderParserFixture
    {
      public class Foo
      {
         public virtual int GetValue()
         {
            return 11;
         }
      }
      public class Bar
      {
         private readonly Foo _foo;
         public Bar(Foo foo)
         {
            _foo = foo;
         }
         public int GetValue()
         {
            return _foo.GetValue();
         }
      }
      [TestMethod]
      public void MyTestMethod()
      {
         var foo = new Mock<Foo>();
         foo.Setup(mk => mk.GetValue()).Returns(16);
         var bar = new Bar(foo.Object);
         Assert.AreEqual(16, bar.GetValue());
      }
    }
