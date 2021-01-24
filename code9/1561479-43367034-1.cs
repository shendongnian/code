    public abstract class ServiceBase {
    	protected readonly IDbConnector dbConnector;
    	
    	public ServiceBase(IDbConnector dbConnector) {
    		this.dbConnector = dbConnector;
    	}
    }
    
    public class UserService : ServiceBase {
    	public UserService(IDbConnector dbConnector) : base(dbConnector) {
    	}
    	
    	// use dbConnector from ServiceBase 
    }
