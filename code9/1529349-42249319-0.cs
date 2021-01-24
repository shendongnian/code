    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using DotNetBrowser;
    using System.Diagnostics;
    using System.Text;
    
    namespace WebApplication7.Controllers
    {
        public class HomeController : Controller
        {
            private static List<string> ajaxUrls = new List<string>();
            Browser browser;        
    
            public string Index()
            {
                Init();
                return "Test page";
            }        
    
            private void Init()
            {
                browser = BrowserFactory.Create();
                browser.Context.NetworkService.ResourceHandler = new AjaxResourceHandler();
                browser.Context.NetworkService.NetworkDelegate = new AjaxNetworkDelegate();
    
                browser.LoadURL("https://www.w3schools.com/xml/ajax_examples.asp");
            }       
    
            private class AjaxResourceHandler : ResourceHandler
            {
                public bool CanLoadResource(ResourceParams parameters)
                {
                    if (parameters.ResourceType == ResourceType.XHR)
                    {
                        Debug.WriteLine("Intercepted AJAX request: " + parameters.URL);
                        ajaxUrls.Add(parameters.URL);
                    }
                    return true;
                }
            }
    
            private class AjaxNetworkDelegate : DefaultNetworkDelegate
            {
                public override void OnDataReceived(DataReceivedParams parameters)
                {
                    if (ajaxUrls.Contains(parameters.Url))
                    {
                        Debug.WriteLine("Captured response for: " + parameters.Url);
                        Debug.WriteLine("MimeType = " + parameters.MimeType);
                        Debug.WriteLine("Charset = " + parameters.Charset);
                        PrintResponseData(parameters.Data);
                    }
                }
    
                private void PrintResponseData(byte[] data)
                {
                    Debug.WriteLine("Data = ");
                    var str = Encoding.UTF8.GetString(data);
                    Debug.WriteLine(str);
                }
            }
        }
    }
