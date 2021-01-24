    public class DataController : Controller
    {
        private readonly IDataAccess dataAccess;
        public DataController(IDataAccess dataAcces)
        {
            this.dataAccess = dataAcces;
        }
    
        public ActionResult ShowData()
        {
            string querystring = "you t-sql query";
            string connectionString = "<you sql connection string>";
    
            this.dataAccess.CreateCommand(querystring, connectionString);
    
            return this.View();
        }
    } 
