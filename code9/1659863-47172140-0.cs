    public class PostedObject{
     public object Data {get;set;}
    }
    
      [HttpPost] 
        public string callBcknd([FromBody]PostedObject body)
        {
        // do things
    
    }
