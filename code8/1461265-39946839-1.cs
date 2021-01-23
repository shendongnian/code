    using System;
    using System.Diagnostics;
    using System.Net;
    
    namespace ConsoleApplication1
    {
    	class Program
    	{
    
    		public class RequestTest
    		{
    			public string Url { get; set; }
    			public int Time { get; set; }
    			public HttpStatusCode StatusCode { get; set; }
    		}
    
    		public static RequestTest Test(string url)
    		{
    			var test = new RequestTest() { Url = url };
    			var sw = new Stopwatch();
    			var request = WebRequest.CreateHttp(test.Url);
    			request.AllowAutoRedirect = true;
    			request.Method = "HEAD";
    			request.Headers.Add("Accept-Language: ru-RU, en; q = 0.5");
    			try
    			{
    				sw.Start();
    				using (var response = (HttpWebResponse)request.GetResponse())
    				{
    					sw.Stop();
    					test.Time = (int)sw.ElapsedMilliseconds;
    					test.StatusCode = response.StatusCode;
    				}
    				return test;
    			}
    			catch (WebException ex)
    			{
    				test.StatusCode = ((HttpWebResponse)ex.Response).StatusCode;
    				return test;
    			}
    		}
    
    		static void Main(string[] args)
    		{
    			var x =  Test("http://monosnap.com/page/faq");
    			Console.WriteLine(x.StatusCode + " " + x.Time.ToString());
    			Console.ReadLine();
    
    		}
    	}
    }
