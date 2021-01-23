    [RoutePrefix("api/PiDBTest")]
    public class PiDBTest : ApiController
    {
        private pidbEntities db = new pidbEntities();
    
        // GET: api/PiDBTest
        [HttpGet]
        [Route("")]
        public IQueryable<PiData> GetPiDatas()
        {
            return db.PiDatas;
        }
    }
