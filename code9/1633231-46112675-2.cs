    // Console app class for running Chromium:
    using CefSharp;
    using CefSharp.OffScreen;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Threading;
    
    namespace ConsoleWebChromiumSample
    {
        public class ChromiumRunner
        {
            private ChromiumWebBrowser browser = null;
    
            public void RunChromiumDemo()
            {
                var settings = new CefSettings()
                {
                    MultiThreadedMessageLoop = true
                };
    
                //Perform dependency check to make sure all relevant resources are in our output directory.
                Cef.Initialize(settings, performDependencyCheck: true, browserProcessHandler: null);
    
                // Create the offscreen Chromium browser.
                browser = new ChromiumWebBrowser("");
                browser.BrowserInitialized += BrowserInitialized;
    
                while (!browser.IsBrowserInitialized)
                {
                    Thread.Sleep(100);
                }
    
                Cef.Shutdown();
            }
    
            private void BrowserInitialized(object sender, EventArgs e)
            {
                Assert.IsTrue(browser.IsBrowserInitialized);
                browser.BrowserInitialized -= BrowserInitialized;
            }
        }
    }
