    public static class Services 
    {
        private static Dictionary<string, string> cache;
        private static object cacheLock = new object();
        public static Dictionary<string,string> AppCache
        {
            get
            {
                lock (cacheLock)
                {
                    if (cache == null)
                    {
                        cache = new Dictionary<string, string>();
                    }
                    return cache;
                }
            }
        }
    }
    public class testController()
    {
        [HttpGet]
        public HttpResponseMessage persist()
        {
            HttpResponseMessage hrm = Request.CreateResponse();
            hrm.StatusCode = HttpStatusCode.OK;
            Services.AppCache.Add(Guid.NewGuid().ToString(), DateTime.Now.ToString());
            string resp = "";
            foreach (string s in Services.AppCache.Keys)
            {
                resp += String.Format("{0}\t{1}\n", s, Services.AppCache[s]);
            }
            resp += String.Format("{0} records.", Services.AppCache.Keys.Count);
            hrm.Content = new StringContent(resp, System.Text.Encoding.ASCII, "text/plain");
            return hrm;
        }        
    }
