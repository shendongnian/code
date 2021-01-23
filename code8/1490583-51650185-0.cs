    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RelevantCodes.ExtentReports;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    
    namespace testingExtentReports
    {
        [TestClass]
        public class UnitTest1
        {
            public ExtentReports extent;
            public ExtentTest test;
            IWebDriver driver;
            [SetUp]
            public void StartReport()
            {
                string reportPath = @"D:\\TestReport.html";
                extent = new ExtentReports(reportPath, true);
                extent.AddSystemInfo("Host Name", "Your Host Name")
                      .AddSystemInfo("Environment", "YourQAEnvironment")
                      .AddSystemInfo("Username", "Your User Name");
                string xmlPath = @"D:\\ExtentConfig.xml";
                extent.LoadConfig(xmlPath);
            }
           
            [Test]
            public void OpenTest1()
            {
              
                test = extent.StartTest("OpenTest1", "test Started");
                test.Log(LogStatus.Pass, "Website is open properly");
                test.Log(LogStatus.Pass, "Successfully Login into agency Portal");
                test.Log(LogStatus.Info, "Click on UI button link");
                test.Log(LogStatus.Fail, "Error Occurred while creating document");
                test.Log(LogStatus.Pass, "Task Released Succssfully");
                test.Log(LogStatus.Warning, "Workflow saved with warning");
                test.Log(LogStatus.Error, "Error occurred while releasing task.");
                test.Log(LogStatus.Unknown, "Dont know what is happning.");
                test.Log(LogStatus.Fatal, "Unhandled exception occured.");
                extent.EndTest(test);
                extent.Flush();
                extent.Close();
            }
        }
    }
