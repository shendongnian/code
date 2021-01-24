    public class BackupController : ApiController
    {
        public IEnumerable<string> GetBackup()
        {
            return new string[] { "value1", "value2" };
        }
        // GET: api/Backup/5
        public string Get(int id)
        {
            return "value";
        }
    }
