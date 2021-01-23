    public class SmsController : ApiController
    {
        private DbContext db = new DbContext();
    
        // GET: api/Sms
        [HttpGet]
        [Route("api/sms")]
        public IQueryable<Sms> GetSms()
        {
            return db.Sms;
        }
        ...
    }
