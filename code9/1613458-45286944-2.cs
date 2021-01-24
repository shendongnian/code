    public class MyController : ODataController {
        private readonly IDataContext db;
    
        public MyController(IDataContext db) {
            this.db = db;
        }
    
        [HttpPost]
        [ODataRoute("RunFile()")]
        public IHttpActionResult RunFile() {
            //..code omitted for brevity
    
            var result = db.SqlQuery<int>("exec MyStoredProc").ToList();
            return Ok(result);
        }
    }
