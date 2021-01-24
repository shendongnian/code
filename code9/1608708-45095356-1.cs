    public class Response
    {
        public bool status {get;set;}
    }
    
    var jsonResponse = JsonConvert.DeserializeObject<Response>(result);
