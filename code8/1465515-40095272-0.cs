    namespace Company.Models
    {
    	public class AgencyBean
    	{
    		public AgencyName{get;set;}
    		public AgencyId{get;set;}
    		// other properties...
    	}
    }
    
    namespace Company.Controllers
    {
    	public class MyController : Controller
    	{
    		private readonly IMyService myService;
    	 
    
    		public MyController(IMyService myService) // <-- this is your dependency injection here...
    		{
    			this.myService = myService; 
    		}
    			
    		[WebMethod]
    		[ScriptMethod(UseHttpGet = true)]
    		public static String createGUID(string name)
    		{
    			var model = new AgencyBean();
    			model.AgencyId = 1;
    			model = myService.getAgency(agencyBean);			
    			return model;
    		}
    	}
    }
    
    namespace Company.Services
    {
    	public class MyService
    	{
    		private readonly IMyRepository myRepository;
    	 
    
    		public MyService(IMyRepository myRepository) // <-- this is your dependency injection here...
    		{
    			this.myRepository = myRepository; 
    		}
    			
    		public AgencyBean getAgency(AgencyBean model){
    			var dataTable = myRepository.getAgencyData(model.AgencyId);
    			// fill other properties of your model you have...
    			// ...
    			// ...
    			return model;
    		}
    	}
    }
    namespace Company.Repositories
    {
    	public class MyRepository : IDatabaseCommon  // <-- some interface you would use to ensure that all repo type objects get connection strings or run other necessary database-like setup methods...
    	{ 
    		private readonly String connectionString{get;set;}
    		
    		public MyRepository()
    		{
    			this.connectionString = //get your connection string from web.config or somewhere else...; 
    		}
    			
    		public DataTable getAgencyData(int id){
    			var dataTable = new DataTable();
    			
    			// perform data access and fill up a data table
    			
    			return dataTable;
    		}
    	}
    }
