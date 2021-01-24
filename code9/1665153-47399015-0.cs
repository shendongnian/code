    [RoutePrefix("api/backup")]
    public class BackupController : ApiController
    {
    	[Route("backup")
        public IEnumerable<string> Backup()
        {
            return new string[] { "value1", "value2" };
        }
    
        // GET: api/Backup/5
    	[Route("get")]
        public string Get(int id)
        {
            return "value";
        }
    }
