        #r "System.Data.dll"
        #r "System.Data.Linq.dll"
        #load "TodoItem.csx"
        using System.Net;
        using System.Data.SqlClient;
        using System.Data.Linq;
        public static async Task<HttpResponseMessage> Run(HttpRequestMessage   req, TraceWriter log)
        {
             log.Info("C# HTTP trigger function processed a request.");
             var connectionString =   System.Configuration.ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString;
             SqlConnection conn = new SqlConnection(connectionString);
             DataContext db = new DataContext(conn);
             Table<TodoItem> todoItems = db.GetTable<TodoItem>();
             IEnumerable<TodoItem> items = todoItems.ToList();
    
             return req.CreateResponse(HttpStatusCode.OK, items);
        }
