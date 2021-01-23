    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net;
    namespace DreamJ
    {
        public class second
        {
            public void Test()
            {
                WebClient webClient = new WebClient();
                webClient.Headers.Add("User-Agent: Other");
                webClient.Headers.Add("Accept", "*/*");
                string content = webClient.DownloadString("https://example.com");
                string result = content.Replace("\"", " ");
                more = result.Replace("},", "},\n");
            }
        
           public string more
           {
               get;
               set;
           }
        }
    }
