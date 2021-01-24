    public class Mrr: IMrr
    { 
    	// This is dependency
    	IDelete _deleteObject;
    	
    	public Mrr()
    	{
    		_deleteObject = new DeleteClass();
    	}
    }
