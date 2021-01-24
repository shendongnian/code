    public class Data
    {
        public string message {get;set;}
        public string name {get;set;}
    }
    
    public class Response
    {
        public bool status {get;set;}
        public Data data {get;set;}
    }
        
    var jsonResponse = JsonConvert.DeserializeObject<Response>(result);
    if (jsonResponse.status != true){
       //your code
    }
