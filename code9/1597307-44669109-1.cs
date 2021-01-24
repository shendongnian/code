    public class MyApi : ApiController
    {
        public static readonly object LockObject = new object();
        [HttpPut]
        [Route("api/Public/SendCommissioning/{serial}/{withChildren}")]
        public HttpResponseMessage SendCommissioning(string serial, bool withChildren)
        {
            lock ( LockObject )
            {
                //Do stuff
            }
        }
    }
