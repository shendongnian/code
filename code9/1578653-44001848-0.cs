    public interface IBaseService<VO, ENT>{
    	IQueryable<VO> GetAll();
    
    	VO Get(object id);
    }
    
    public abstract class BaseService<VO, ENT> : IBaseService<VO, ENT>{
    	
    	MyContext db;
    
    	public BaseService(MyContext db){
    		this.db = db;
    	}
        public IQueryable<VO> GetAll(){
            return db.Set<ENT>().ProjectTo<VO>();
        }
    }
