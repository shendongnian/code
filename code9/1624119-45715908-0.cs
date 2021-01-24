    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    
    namespace test01
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
                PostData("a", "/");
            }
    
    		public static WebResponse PostData(string body, string url)
    		{
    			WebResponse webResponse = null;
    			try
    			{
    				var uri = new Uri(string.Format("http://google.it" + url, string.Empty));
    				var webRequest = (HttpWebRequest)WebRequest.Create(uri);
    				webRequest.Headers.Add("Cookie","test");
    				webRequest.Headers.Add("_RequestVerificationToken", "test");
    				webRequest.Method = "POST";
    				webRequest.ContentType = "application/xml";
    				byte[] bytes = Encoding.UTF8.GetBytes(body);
    				webRequest.ContentLength = bytes.Length;
    				Stream requestStream = webRequest.GetRequestStream();
    				requestStream.Write(bytes, 0, bytes.Length);
    				webResponse = webRequest.GetResponse();
    			}
    			catch (Exception exception)
    			{
    				Console.WriteLine(exception);
    			}
    			return webResponse;
    		}
        }
    }
