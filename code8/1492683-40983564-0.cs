    public Interface IMyDataService<TObject> where TObject : class
    {
       TObject Update(TObject obj, int id);
    }
    
    public class MyDataService<TObject>:IMyDataService<TObject>
     where TObject : class
    {
        private readonly MyDataContext context;
    
        public MyDataService(MyDataContext ct)
        {
            context = ct;
        }
    
        public TObject Update(TObject obj, int id)
        {
            var r = new GenericRepository<TObject>(context);
            return r.Update(obj, id);
        }
    }
