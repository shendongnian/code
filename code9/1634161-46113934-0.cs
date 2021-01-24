    public class ParentDTO 
    {
     public int parentId{get; set;}
     public string tagName{ get; set;}
    }
    
    [HttpPost]
    public JObject AddTag([FromBody] ParentDTO parent)
    {
    
    }
