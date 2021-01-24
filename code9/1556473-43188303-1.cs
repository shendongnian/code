    public abstract class DAO
    {
    	public long id { get; set; }
    
    	public void fromDictionary(Dictionary<string, object> obj)
    	{
    		//Does own part in the method
    		id = (long)obj["id"];
    
    		//Calls most derived implementation
    		fromDictionaryOperation(obj); 
    	}
    	//Forces child to implement its part
    	protected abstract void fromDictionaryOperation(Dictionary<string, object> obj);
    }
    //Is forced to implement its part, and the base implementation will be executed always
    public class Area : DAO
    {
    	public string name { get; set; }
    	protected override void fromDictionaryOperation(Dictionary<string, object> obj)
    	{
    		name = (string)obj["name"];
    	}
    }
    //Is NOT forced to implement method, and MUST call base.fromDictionary() for all this to work properly, but is NOT FORCED TO.
    public class CircularArea : Area
    {
    	public float radius { get; set; }
    	protected override void fromDictionaryOperation(Dictionary<string, object> obj)
    	{
    		radius = (float)obj["radius"];
    		base.fromDictionary(obj);
    	}
    }
