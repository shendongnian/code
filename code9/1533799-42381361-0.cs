    [SetUpFixture]
        public class SETUP_THAT_WILL_GET_CALL_LATER
        {
            [OneTimeSetUp]
            public void OneTimeSetUp()
            {
                var applicationDirectory = TestContext.CurrentContext.TestDirectory;
                var applicationPath = Path.Combine(applicationDirectory, @"..\..\..\, "your debug folder path here", "your application.exe here");
                Application = Application.Launch(applicationPath);
    
                Thread.Sleep(2000);
    
                Window = Application.GetWindow("Title of your application", InitializeOption.WithCache);
            }
    
            [OneTimeTearDown()]
            public void OneTimeTearDown()
            {
                Window.Dispose();
                Application.Dispose();
            }
    
            public static Application Application;
            public static Window Window;
        }
