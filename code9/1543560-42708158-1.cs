    public class Rootobject {
       public Response response { get; set; }
    }
    
    public class Response {
       public Result result { get; set; }
       public string uri { get; set; }
    }
    
    public class Result {
       public Leads Leads { get; set; }
    }
    
    public class Leads {
       public Row[] row { get; set; }
    }
    
    public class Row {
       public string no { get; set; }
       public FL[] FL { get; set; }
    }
    
    public class FL {
       public string val { get; set; }
       public string content { get; set; }
    }
