    #create 2 files#
    1) ExtentManager.cs n write following code
        using AventStack.ExtentReports;
        using AventStack.ExtentReports.Reporter;
        using AventStack.ExtentReports.Reporter.Configuration
    namespace ProTradeExeAutomation
    {
         public class ExtentManager
            {
                    public static ExtentHtmlReporter htmlReporter;
                    private static ExtentReports extent;
            
                    private ExtentManager()
                    {
            
                    }
                    public static ExtentReports GetInstance()
                    {
                        if (extent == null)
                        {
                        
        
        string startupPath = System.IO.Directory.GetCurrentDirectory();
                        string startupPathSubString = startupPath.Substring(0, 49);
                        string fullProjectPath = new Uri(startupPathSubString).LocalPath;
                        string reportpath = fullProjectPath + "Reports\\SampleReport.html";
                        
                        htmlReporter = new ExtentHtmlReporter(reportpath);
                        htmlReporter.Configuration().Theme = Theme.Dark;
        
                        extent = new ExtentReports();
                        extent.AttachReporter(htmlReporter);
                        extent.AddSystemInfo("Host Name", "ABC");
                        extent.AddSystemInfo("Environment", "Test QA");
                        extent.AddSystemInfo("Username", "XYZ");
                        htmlReporter.LoadConfig("urpath\\extent-config.xml"); //Get the config.xml file 
                    }
                    return extent;
                }
        }
    }
    ##In Test File create obj of ExtentManager n use to create test##
    
     public class LoginPageTest
        {
            LoginPage loginPage;
            ExtentReports rep = ExtentManager.GetInstance();
            ExtentTest test;
    
            [Test,Order(1)]
            public void LoginPageTestMethod()
            {
                test = rep.CreateTest("LoginPageTest");
                test.Log(Status.Info, "Starting test");
                loginPage.LogginPage(Constant.USERNAME, Constant.PASSWORD);
                Thread.Sleep(9000);
                Thread.Sleep(5000);
                try
                {
                    Assert.IsTrue(true);
                    test.Pass("Test passed");
                }
                catch (AssertionException)
                {
                    test.Fail("Test failed");
                }
                rep.Flush();//remember to do this
        }
