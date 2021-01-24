    public class BackupController : ApiController
    {
        public IEnumerable<string> GetBackupList() // or even just Get()
        {
            return new string[] { "value1", "value2" };
        }
        // GET: api/Backup/5
        public string Get(int id)
        {
            return "value";
        }
    }
