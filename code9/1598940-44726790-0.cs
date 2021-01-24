    public class TableNameController : Controller
    {
        private readonly ConnectionStringName _db;
    
        public TableNameController(ConnectionStringName db)
        {
            _db = db;
        }
    }
