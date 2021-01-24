    public class MyController : ApiController
    {
        private readonly ICache<MyObject> _cache;
        public MyController(ICache<MyObject> cache)
        {
            _cache = cache;
        }
        public IHttpActionResult GetCached()
        {
             var myObj = _cache.Get("myKey");
             if(myObj == null)
             {
                 myObj = GetObjectFromWhereverYouWant();
                 _cache.Put(myObj, "myKey");
             }
             return Ok(myObj);
        }
