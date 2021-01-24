    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    using System.Text;
    
    namespace OxfDictionary
    {
        class Program
        {
            static void Main(string[] args)
            {
                HttpWebRequest req = null;
                
                string PrimeUrl = "https://od-api.oxforddictionaries.com:443/api/v1/entries/en/";
                string uri = PrimeUrl + "robot";
                req = (HttpWebRequest)HttpWebRequest.Create(uri);
    
                //These are not network credentials, just custom headers
                req.Headers.Add("app_id", "5a......3");
                req.Headers.Add("app_key", "d12............1a0");
    
                req.Method = WebRequestMethods.Http.Get;
                req.Accept = "application/json";
    
                using (HttpWebResponse HWR_Response = (HttpWebResponse)req.GetResponse())
                using (Stream respStream = HWR_Response.GetResponseStream())
                using (StreamReader sr = new StreamReader(respStream, Encoding.UTF8))
                {
                    string theJson = sr.ReadToEnd();
                    Debug.WriteLine(theJson);
                    Console.WriteLine(theJson);
                }
                Console.ReadKey();
            }
        }
    }
