    table values_store
    (
        ss_id varchar(50),
        user_name varchar(250)
    )
    public class ReturnValuesRepository
    {
        var db = new ValuesEntities();
        public IEnumerable<ReturnClass> GetReturnClasses()
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
    
    
