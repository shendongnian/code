    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.AssemblyResolve += MyResolveEventHandler;
            //Your code
        }
        private Assembly MyResolveEventHandler(object sender, ResolveEventArgs args)
        {
           return Assembly.LoadFile(@"YourPath\YourName.dll");
        }
    }
