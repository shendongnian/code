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
            public string Test()
            {
                WebClient webClient = new WebClient();
                webClient.Headers.Add("User-Agent: Other");
                webClient.Headers.Add("Accept", "*/*");
                string content = webClient.DownloadString("https://example.com");
                string result = content.Replace("\"", " ");
                string more = result.Replace("},", "},\n");
                return more;
            }
        
        }
    }
