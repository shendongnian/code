    using System.Net.Http;
    using log4net;
    using System.Text;
    
    namespace Stackoverflow
    {
        public static class Enc {
    
            private static readonly ILog log = LogManager.GetLogger(typeof(Enc));
    
            public static string GetRequest(HttpClient client, string url, int codepage) {
                using (HttpResponseMessage response = client.GetAsync(url).Result) {
                    var byteArray = response.Content.ReadAsByteArrayAsync().Result;
                    var result = Encoding.GetEncoding(codepage).GetString(byteArray, 0, byteArray.Length);
                    return result;
                }
            }
    
            public static void Example(HttpClient client, string url) {
                string result1 = GetRequest(client, url, 1252);
                string result2 = GetRequest(client, url, 28591);
                log.Debug(result1);
                log.Debug(result2);
            }
        }
    }
