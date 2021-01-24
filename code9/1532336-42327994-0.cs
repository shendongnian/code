    // In your AtlasDataKernal
    public class DatabaseContext : IDataContext
    {
          // implementation
    }
    
    // In your AtlasBusinessKernal
    public class MyBusinessLogic
    {
         private IDataContext dataContext;
         public MyBusinessLogic(IDataContext context)
         {
            this.dataContext = context;
         }
    }
    // In your web application or whatever project type it might be
    public class MyWebApp
    {
          public DoSomeThing()
          {
              IDataContext context = new DatabaseContext();
              MyBusinessLogic logic = new MyBusinessLogic(context);
          }
    }
