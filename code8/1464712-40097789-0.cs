    #r "System.Data.Linq"
    #load "TodoItem.csx"
    
    using System.Net;
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    using System.Configuration;
    
    public static void Run(string input, TraceWriter log)
    {        
        var cnnString  = ConfigurationManager.ConnectionStrings["MS_TableConnectionString"].ConnectionString;
        DataContext db = new DataContext(cnnString);     
        Table<todoItem> todoItems = db.GetTable<todoItem>();        
        IQueryable<todoItem> itemQuery = from todoItem in todoItems select todoItem;
    
        foreach (todoItem item in itemQuery)
        {
            log.Info($"ID={item.id}, Text={item.text}");
        }
    
        return;
    }
