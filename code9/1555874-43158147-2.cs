    public class DataController : Controller
        {
            private readonly IDataAccess dataAccess;
            public DataController()
            {
                this.dataAccess = new DataAccess();
            }
    
            public ActionResult ShowData()
            {
                string querystring = "you t-sql query";
                string connectionString = "<you sql connection string>";
    
                this.dataAccess.CreateCommand(querystring, connectionString);
    
                return this.View();
            }
        }
