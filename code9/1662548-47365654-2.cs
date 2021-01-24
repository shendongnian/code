    using System;
    using System.Collections.Generic;
    using System.Net;
    using HtmlAgilityPack;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium;
    using System.Threading;
    namespace test
    {
        class Program
        {
        public static void Main(string[] args)
        {
                string url = "https://www.google.com";
                IWebDriver driver = new FirefoxDriver();
               driver.Navigate().GoToUrl("https://enquiry.indianrail.gov.in");
                Console.WriteLine("Step 1");
                driver.FindElement(By.XPath("//a[@id='ui-id-2']")).Click();
                Thread.Sleep(10000);
                Console.WriteLine("Step 2");
                driver.FindElement(By.XPath("//input[@id='viaStation']")).SendKeys("NEW DELHI [NDLS]");
                Thread.Sleep(2000);
                Console.WriteLine("Step 3");
                driver.FindElement(By.XPath("//button[@id='viaStnGoBtn']")).Click();
                //PRESS A KEY WHEN THE HTML IS FULLY LOADED
                Console.ReadKey();
                HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(driver.PageSource);
                HtmlNodeCollection nodeCol = doc.DocumentNode.SelectNodes("//body//tr[@class='altBG']");
                foreach(HtmlNode node in nodeCol){
                    Console.WriteLine("Trip:");
                    foreach(HtmlNode child in node.ChildNodes)
                    {
                        Console.WriteLine("\t" + child.InnerText);
                    }
                }
                //Console.WriteLine(doc.DocumentNode.InnerHtml);
                Console.ReadKey();
        }
