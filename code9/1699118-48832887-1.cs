    using System;
    using System.Collections.Specialized;
    using System.Net;
    
    namespace ConsoleApp18
    {
        public class NoRedirectWebClient : WebClient
        {
            protected override WebRequest GetWebRequest(Uri address)
            {
                var temp = base.GetWebRequest(address) as HttpWebRequest;
                temp.AllowAutoRedirect = false;
                return temp;
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                MakeRequest(new WebClient());//Prints the AboutHeader
                Console.WriteLine();
                MakeRequest(new NoRedirectWebClient());//Prints the IndexHeader
                Console.ReadLine();
            }
    
            private static void MakeRequest(WebClient webClient)
            {
                var loginUrl = @"http://localhost:50900/Home/Login";
                NameValueCollection formData = new NameValueCollection();
                formData["username"] = "batman";
                formData["password"] = "1234";
    
                webClient.UploadValues(loginUrl, "POST", formData);
    
                string allheaders = "";
                for (int i = 0; i < webClient.ResponseHeaders.Count; i++)
                    allheaders += Environment.NewLine + webClient.ResponseHeaders.GetKey(i) + " = " +
                                  webClient.ResponseHeaders.Get(i);
    
                Console.WriteLine("******"+webClient.GetType().FullName+"*******");
                Console.Write(allheaders);
            }
        }
    }
