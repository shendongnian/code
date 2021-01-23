    [RoutePrefix("api/PolicyInfo")]
    public class PolicyInfoController : ApiController
    {
    	GenericRepository<ApplicationDbContext, PolicyInfo> policycontext;        
    
    	public PolicyInfoController(IGenericRepository<ApplicationContext,PolicyInfo> policyContext)
    	{
    		//use the context here... e.g.: Save the reference to the instance field.
    		this.policyContext = policyContext;
    	}
    }
