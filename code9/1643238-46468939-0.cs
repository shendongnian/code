    void Main()
    {
    	// create array
    	DataFromJSON[] data = new UserQuery.DataFromJSON[3];
    	data[0] = new DataFromJSON() { Data = "val0", Created = DateTime.Now };
    	data[1] = new DataFromJSON() { Data = "val1", Created = DateTime.Now };
    	data[2] = new DataFromJSON() { Data = "val2", Created = DateTime.Now };
    
    	var values = from x in data
    				 select x.Data;
    	
    	values.Dump();
    	
    }
    
    // Define other methods and classes here
    public class DataFromJSON
    {
    	public string Data { get; set; }
    	public DateTime Created { get; set;}
    }
