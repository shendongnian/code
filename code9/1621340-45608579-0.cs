    [TestClass]
        public class UnitTest1
        {
            Class2 myClass2 = new Class2();
    
            public static IWebDriver webDriver;
    
            [AssemblyInitialize]
            public static void invokeBrowser(TestContext context)
            {
                webDriver = new ChromeDriver(@"C:\Selenium\");
            }
    
            [TestMethod]
            public void TestMethod1()
            {
                myClass2.RandomMethod();
            }
    }
    //Class2
    [TestClass]
        public class Class2
        {
            //[TestMethod]
            public void RandomMethod()
            {
                UnitTest1.webDriver.Navigate().GoToUrl("http://google.com");
            }
        }
