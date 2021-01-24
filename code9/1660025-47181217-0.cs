    public class XYZManager : IDisposable
 	{
		 public static  XYZManager Create()
		 {
		     return  new XYZManager(new ApplicationDbContext());
		 }
         private readonly ApplicationDbContext DbContext;
                           
         public XYZManager(ApplicationDbContext dbContext)
         {
             DbContext = dbContext;
         }
         public string SomeInfo {get;set;}
		 public string GetFullDetails () 
		 {
			 return dbContext.getFullDetails();
		 }
         // dispose
	 }
