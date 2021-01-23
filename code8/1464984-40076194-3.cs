    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:1748/api/TestAPI");
                req.Method = "post"; ;
                var aaa = Encoding.Default.GetBytes("\"Test\"");
                req.ContentType = "application/json";
                req.ContentLength = aaa.Length;
                req.GetRequestStream().Write(aaa, 0, aaa.Length);
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                using (System.IO.StreamReader sr = new System.IO.StreamReader(res.GetResponseStream()))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
        }
    }
