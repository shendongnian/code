    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestMethod()
        {
            var callCount = 0;
            Isolate.WhenCalled(() => Bar.Foo(2, 10))
                .WithExactArguments()
                .DoInstead(context =>
                {
                    callCount++;
                    context.WillCallOriginal();
                });
            Bar.Foo(2, 6);
            Bar.Foo(2, 10);
            Bar.Foo(2, 10);
            Assert.AreEqual(2, callCount);
        }
    }
