    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    using System.Web;
    
    namespace webgateway
    {
        public class RequestHandler : IHttpAsyncHandler, IDisposable
        {
    
    
            public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
            {
    
                RequestContext requestContext = new RequestContext(cb, context, extraData);
    
                Service.Instance.QueueRequest(requestContext);
    
                return requestContext;
                
            }
    
    
            //Start could be called from the Global asax or by adding this attribute to the Assembly.cs 
            //[assembly: PreApplicationStartMethod(typeof(webgateway.RequestHandler), "Start")]
            public static void Start()
            {
    
                Service.Instance.Start();
            } 
    
            public void EndProcessRequest(IAsyncResult result) {
            }
            public bool IsReusable { get { return true; } }
            public void ProcessRequest(HttpContext context) { }
            public void Dispose() { }
        }
    
    }
    
    
    public sealed class Service
    {
        
        private static readonly Service _Instance = new Service();
        public static Service Instance
        {
            get { return _Instance; }
        }
        private Service()
        {
        }
    
    
        private static bool _running = false;
    
        private BlockingCollection<RequestContext> blockingQueue = new BlockingCollection<RequestContext>(new ConcurrentQueue<RequestContext>());
    
    
        public void Start()
        {
            _running = true;
            ThreadPool.QueueUserWorkItem(worker, null);
           
        }
    
        private void worker(object state)
        {
    
            RequestContext requestContext;
    
            while (_running)
            {
    
                //Block until a new item is added to the queue
                if (blockingQueue.TryTake(out requestContext, 10000))
                {
                                    
                    //You could delegate the work to another function , class , library or process inline here... 
                    
                    //Simulate a random delay 
                    Thread.Sleep((new Random()).Next(1000, 5000));
    
    
                    //Make sure the client is connected before sending the response 
                    if (requestContext.HttpContext.Response.IsClientConnected)
                    {
                        requestContext.HttpContext.Response.BufferOutput = false;
                        requestContext.HttpContext.Response.ContentType = "text/plain";
                        requestContext.HttpContext.Response.Write(requestContext.HttpContext.Request["echo"]);
                        requestContext.HttpContext.Response.Flush();
                        requestContext.CompleteCall();
                    }
    
                }
    
            }
    
        }
    
        public void Stop()
        {
            _running = false;
        }
    
        public void QueueRequest(RequestContext requestContext)
        {
    
            if (!blockingQueue.TryAdd(requestContext))
            {
                //handle error 
            }
        }
        
    }
    
    public class RequestContext : IAsyncResult
    {
      
        private ManualResetEvent _event;
        private object _lock = new Object();
        private AsyncCallback _callback;
        private HttpContext _httpContext;
        private bool _completed;
        private bool _completedSynchronously;
        private object _state;
    
        public RequestContext(AsyncCallback cb, HttpContext hc, object state)
        {
            _callback = cb;
            _httpContext = hc;
            _completedSynchronously = false;
            _completed = false;
            _state = state;
        }
    
        public HttpContext HttpContext
        {
            get { return _httpContext; }
        }
    
        public void CompleteCall()
        {
            lock (_lock)
            {
                _completed = true;
                if (_event != null)
                {
                    _event.Set();
                }
            }
    
            _callback?.Invoke(this);
        }
    
        public bool IsCompleted
        {
            get { return _completed; }
        }
    
        public bool CompletedSynchronously
        {
            get { return _completedSynchronously; }
        }
    
        public object AsyncState
        {
            get { return _state; }
        }
    
        public WaitHandle AsyncWaitHandle
        {
            get
            {
                lock (_lock)
                {
    
                    if (_event == null)
                    {
                        _event = new ManualResetEvent(IsCompleted);
                    }
                    return _event;
                }
            }
        }
    
    }
    
