    [TestClass]
    public class MyWrapperTests
    {
        // Will not pass
        [TestMethod]
        public void ShouldAllowAsyncAction()
        {
            // This will throw an exception
            MyWrapper.Execute(async () =>
            {
                Assert.IsTrue(true);
                await Task.Run(() =>
                {
                    Console.WriteLine("Kind of async");
                });
            });
        }
        // Will pass, since ArgumentException is expected.
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowArgumentExceptionWhenAsync()
        {
            // This will throw an exception. But that's expected.
            MyWrapper.Execute(async () =>
            {
                Assert.IsTrue(true);
                await Task.Run(() =>
                {
                    Console.WriteLine("Kind of async");
                });
            });
        }
        // Passes
        [TestMethod]
        public void ShouldAllowSyncAction()
        {
            MyWrapper.Execute(() =>
            {
                Assert.IsTrue(true);
            });
        }
    }
