    class RateLimitCacheEntry
    {
        public int RequestsLeft;
        public DateTime ExpirationDate;
    }
    /// <summary>
    /// Partially based on
    /// https://stackoverflow.com/questions/3082084/how-do-i-implement-rate-limiting-in-an-asp-net-mvc-site
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class RateLimitAttribute : ActionFilterAttribute
    {
        private static Logger Log = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Window to monitor <see cref="RequestCount"/>
        /// </summary>
        public int Seconds { get; set; }
        
        /// <summary>
        /// Maximum amount of requests to allow within the given window of <see cref="Seconds"/>
        /// </summary>
        public int RequestCount { get; set; }
        /// <summary>
        /// ctor
        /// </summary>
        public RateLimitAttribute(int s, int r)
        {
            Seconds = s;
            RequestCount = r;
        }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            try
            {
                var clientIP = RequestHelper.GetClientIp(actionContext.Request);
                // Using the IP Address here as part of the key but you could modify
                // and use the username if you are going to limit only authenticated users
                // filterContext.HttpContext.User.Identity.Name
                var key = string.Format("{0}-{1}-{2}",
                    actionContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                    actionContext.ActionDescriptor.ActionName,
                    clientIP
                );
                var allowExecute = false;
                var cacheEntry = (RateLimitCacheEntry)HttpRuntime.Cache[key];
                if (cacheEntry == null)
                {
                    var expirationDate = DateTime.Now.AddSeconds(Seconds);
                    HttpRuntime.Cache.Add(key,
                        new RateLimitCacheEntry
                        {
                            ExpirationDate = expirationDate,
                            RequestsLeft = RequestCount,
                        },
                        null,
                        expirationDate,
                        Cache.NoSlidingExpiration,
                        CacheItemPriority.Low,
                        null);
                    allowExecute = true;
                }
                else
                {
                    // Allow and decrement
                    if (cacheEntry.RequestsLeft > 0)
                    {
                        HttpRuntime.Cache.Insert(key,
                            new RateLimitCacheEntry
                            {
                                ExpirationDate = cacheEntry.ExpirationDate,
                                RequestsLeft = cacheEntry.RequestsLeft - 1,
                            },
                            null,
                            cacheEntry.ExpirationDate,
                            Cache.NoSlidingExpiration,
                            CacheItemPriority.Low,
                            null);
                        allowExecute = true;
                    }
                }
                if (!allowExecute)
                {
                    Log.Error("RateLimited request from " + clientIP + " to " + actionContext.Request.RequestUri);
                    actionContext.Response
                        = actionContext.Request.CreateResponse(
                            (HttpStatusCode)429,
                            string.Format("You can call this {0} time[s] every {1} seconds", RequestCount, Seconds)
                        );
                }
            }
            catch(Exception ex)
            {
                Log.Error(ex, "Error in filter attribute");
                throw;
            }
        }
    }
    public static class RequestHelper
    {
        /// <summary>
        /// Retrieves the client ip address from request
        /// </summary>
        public static string GetClientIp(HttpRequestMessage request)
        {
            if (request.Properties.ContainsKey("MS_HttpContext"))
            {
                return ((HttpContextWrapper)request.Properties["MS_HttpContext"]).Request.UserHostAddress;
            }
            if (request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
            {
                RemoteEndpointMessageProperty prop;
                prop = (RemoteEndpointMessageProperty)request.Properties[RemoteEndpointMessageProperty.Name];
                return prop.Address;
            }
            return null;
        }
    }
