    public class YourApiController : ApiController
    {
        [HttpGet]
        [Route("api/getDateFromServer")]
        public DateTime GetDateFromServer()
        {
            return DateTime.Now;
        }
    }
