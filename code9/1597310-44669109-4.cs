    //This is a sample with Request/Result classes (Simply implement as you see fit)
    public static class MyBackgroundWorker
    {
        private static ConcurrentQueue<KeyValuePair<Guid, Request>> _queue = new ConcurrentQueue<KeyValuePair<Guid, Result>>()
        public static ConcurrentDictionary<Guid, Result> Results = new ConcurrentDictionary<Guid, Result>();
        static MyBackgroundWorker()
        {
             var thread = new Thread(ProcessQueue);
             thread.Start();
        }
        private static void ProcessQueue()
        {
             KeyValuePair<Guid, Request> req;
             while(_queue.TryDequeue(out req))
             {
                 //Do processing here (Make sure to do it in a try/catch block)
                 Results.TryAdd(req.Key, result);
             }
        }
        public static Guid AddItem(Request req)
        {
            var guid = new Guid();
            _queue.Enqueue(new KeyValuePair(guid, req));
            return guid;
        }
    }
    public class MyApi : ApiController
    {
        [HttpPut]
        [Route("api/Public/SendCommissioning/{serial}/{withChildren}")]
        public HttpResponseMessage SendCommissioning(string serial, bool withChildren)
        {
            var guid = MyBackgroundWorker.AddItem(new Request(serial, withChildren));
            return guid;
        }
        [HttpGet]
        [Route("api/Public/GetCommissioning/{guid}")]
        public HttpResponseMessage GetCommissioning(string guid)
        {
            if ( MyBackgroundWorker.Results.TryRemove(new Guid(guid), out Result res) )
            {
                return res;
            }
            else
            {
                //Return result not done
            }
        }
    }
