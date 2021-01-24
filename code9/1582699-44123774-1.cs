        public class MyClassWhereDbContextIsNeeded
        {
           private readonly ConfigurationDbContext dbContext;
           
           //Inject context instance here.
           public MyClassWhereDbContextIsNeeded(ConfigurationDbContext dbContext)
           {
              this.dbContext = dbContext;
           }
           public void SomeMethod()
           {
              //Use DbContext here e.g. Get customers from database.
              var customers =  dbContext.Customers.ToList());
           }
         }
