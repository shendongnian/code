    public class Service {
    
        private readonly IMyDbContext _myDatabaseContext;
        private readonly IMyFactory _myfactory;
    
        public Service (IMyDbContext myDbContext, IMyFactory myfactory) {
            _myDatabaseContext = myDbContext;
            _myfactory = myfactory
        }
    
        public void Create() {
            var extraProperty = myDatabaseContext.Get(something);
            var myNewObject = _myFactory.Create(extraProperty);
            _myDatabaseContext.Add(myNewObject);
            _myDatabaseContext.SaveChanges();
        }
    }
