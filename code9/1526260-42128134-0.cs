    Change the api code 
    
    public class test { 
    public int id {get;set;} 
    public string usuario {get;set;} 
    public string latitude {get;set;} 
    public string longitude { get; set; } 
    } 
    
    [HttpPost] 
    // POST: api/Leads 
    public bool Post(test objTest) 
    { 
    //Do stuff return true; 
    }
