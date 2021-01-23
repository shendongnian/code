    void Main()
    {
    	var inputStr = @"[{'sId':'HSFJFKJ.dsfhshd','min':'AKK213AD23456','info':'text'},
    	{'sId':'HSFJFKJ.dsd7shd','min':['BKK213AB1CD23456','BKK213AB1CD23456'],'info':'text'},
    	{'sId':'HSFJFKJ.dsdf7shd','min':'BKK213AB1CD23456','info':'text'},
    	{'sId':'HSFJFKJ.dsdd7shd','min':'CKK213AB1CD23456','info':'text'}]";
    	
    	inputStr = inputStr.Replace("'min':'","'min':['").Replace("','info'","'],'info'");
    	
    	var dest = JsonConvert.DeserializeObject<test[]>(inputStr);
    
    	var finalList = dest.Select(d => new test() { sId=d.sId,min=d.min.Distinct().ToArray(),info=d.info });
        //This will have your final string
    	var output = JsonConvert.SerializeObject(finalList);
    	
    }
    
    // Define other methods and classes here
    public class test
    {
    	public string sId { get; set; }
    	public string[] min { get; set; }
    	public string info { get; set; }
    }
