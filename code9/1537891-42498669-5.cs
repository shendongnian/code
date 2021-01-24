    table values_store
    (
        ss_id varchar(50),
        user_name varchar(250)
    )
    public class ReturnValuesRepository
    {
        public IEnumerable<ReturnClass> GetReturnClasses()
        {   
            //As commented by @Enigmativity if your `BitDatabaseEntities` is `IDisposable` (sure if it inherits from `DbContext`) you should wrap it in a `using` block
            using(var db = new ValuesEntities())
            {
                var list = (from r in db.values_store select new 
                       ReturnClass
                         {
                             SSId=r.ss_id,
                             Name=r.user_name
                        }).AsEnumerable();
    
                return list;
            }
        }
    }
    
    
