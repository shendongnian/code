    using AventStack.ExtentReports;
    using AventStack.ExtentReports.Reporter;
    using AventStack.ExtentReports.Reporter.Configuration;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System;
    
    namespace FrameworkForJoe
    {
        [TestFixture]
        public class SampleTest
        {
            private static IWebDriver driver;
            private static ExtentReports extent;
            private static ExtentHtmlReporter htmlReporter;
            private static ExtentTest test;
    
            [OneTimeSetUp]
            public void SetupReporting()
            {
                htmlReporter = new ExtentHtmlReporter(@"C:\Git\joesreport.html");
    
                htmlReporter.Configuration().Theme = Theme.Dark;
    
                htmlReporter.Configuration().DocumentTitle = "JoesDocument";
    
                htmlReporter.Configuration().ReportName = "JoesReport";
    
                /*htmlReporter.Configuration().JS = "$('.brand-logo').text('test image').prepend('<img src=@"file:///D:\Users\jloyzaga\Documents\FrameworkForJoe\FrameworkForJoe\Capgemini_logo_high_res-smaller-2.jpg"> ')";*/
                htmlReporter.Configuration().JS = "$('.brand-logo').text('').append('<img src=D:\\Users\\jloyzaga\\Documents\\FrameworkForJoe\\FrameworkForJoe\\Capgemini_logo_high_res-smaller-2.jpg>')";
                extent = new ExtentReports();
    
                extent.AttachReporter(htmlReporter);
            }
    
            [SetUp]
            public void InitBrowser()
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();            
            }
    
            [Test]
            public void PassingTest()
            {
                test = extent.CreateTest("Passing test");
    
                driver.Navigate().GoToUrl("http://www.google.com");
    
                try {
                    Assert.IsTrue(true);
                    test.Pass("Assertion passed");
                } catch (AssertionException)
                {
                    test.Fail("Assertion failed");
                    throw;
                }
            }
    
            [Test]
            public void FailingTest()
            {
                test = extent.CreateTest("Failing test");
    
                driver.Navigate().GoToUrl("http://www.yahoo.com");
    
                try
                {
                    Assert.IsTrue(false);
                    test.Pass("Assertion passed");
                }
                catch (AssertionException)
                {
                    test.Fail("Assertion failed");
                    throw;
                }
            }
    
            [TearDown]
            public void CloseBrowser()
            {
                driver.Quit();
            }
    
            [OneTimeTearDown]
            public void GenerateReport()
            {
                extent.Flush();
            }
        }
    }
