    public abstract class MyBaseApiController : ApiController
    {
        public virtual IHttpActionResult MyReuseMethod(bool isTrueOrFalse)
        {
            return Ok();
        }
    }
