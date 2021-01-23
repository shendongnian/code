    public class HierarchyController : ApiController
    {
        public IHttpActionResult Get(string keyLevels)
        {
            var keys = keyLevels.Split('/');
            // ... do stuff with your keys
            return Ok(keys);
        }
    }
