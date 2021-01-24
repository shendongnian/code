    using AjaxRequest.Models;
    using DotNetBrowser;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Web.Http;
    
    namespace AjaxRequest.Controllers
    {
        public class ValuesController : ApiController
        {
    
            private static ManualResetEvent waitEvent;
            private static List<string> ajaxUrls = new List<string>();
            private static List<string> sourceDat = new List<string>();
            private static Browser browser;
    
            public ValuesController()
            {
                waitEvent = waitEvent = new ManualResetEvent(false);
                browser = BrowserFactory.Create();
                browser.Context.NetworkService.ResourceHandler = new AjaxResourceHandler();
                browser.Context.NetworkService.NetworkDelegate = new AjaxNetworkDelegate();
    
                browser.LoadURL("https://www.w3schools.com/xml/ajax_examples.asp");
                //browser.Dispose();
            }
    
            // GET api/values
            public IEnumerable<string> Get()
            {
                //Init();
                waitEvent.WaitOne();
                return sourceDat;
    
            }
    
            // GET api/values/5
            public string Get(int id)
            {
    
                return "value";
    
            }
    
            // POST api/values
            public void Post([FromBody]string value)
            {
            }
    
            // PUT api/values/5
            public void Put(int id, [FromBody]string value)
            {
            }
    
            // DELETE api/values/5
            public void Delete(int id)
            {
            }
    
            //private  void Init()
            //{
    
            //}
    
            public class AjaxResourceHandler : ResourceHandler
            {
                public bool CanLoadResource(ResourceParams parameters)
                {
                    if (parameters.ResourceType == ResourceType.XHR && parameters.URL.Contains("https://123movies.is/ajax/v2_get_sources"))
                    {
    
                        ajaxUrls.Add(parameters.URL);
    
                    }
                    return true;
                }
            }
    
            public class AjaxNetworkDelegate : DefaultNetworkDelegate
            {
                public override void OnDataReceived(DataReceivedParams parameters)
                {
                    if (ajaxUrls.Contains(parameters.Url))
                    {
    
                        PrintResponseData(parameters.Data);
    
                    }
    
                }
                public void PrintResponseData(byte[] data)
                {
    
                    var str = Encoding.UTF8.GetString(data);
    
                    BookSource _sources = JsonConvert.DeserializeObject<BookSource>(str);
                    sourceDat.Add(_sources.ToString());
                    waitEvent.Set();
                    browser.Dispose();
                    //source.Add(_sources);
    
                    //return source;
                }
    
            }
    
        }
    }
