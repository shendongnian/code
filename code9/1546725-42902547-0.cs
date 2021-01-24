    public class Mrr: IMrr
    { 
    	// This is dependency
    	IDelete _deleteObject;
    	
    	public Mrr(IDelete deleteObject)
    	{
    		_deleteObject = deleteObject;
    	}
    
       public int Delete(double obj)
       {
            int rtcode = somefunction(obj);
            int DeleteMrr = _deleteObject.DeleteFunction(rtcode);  
            return 0;
       }
    }
    public interface IDelete
    {
    	int DeleteFunction(int rtcode);
    }
