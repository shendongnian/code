    public class Data { 
            public string ID {get;set;}
             public string colour {get;set;}   // This can be renamed into Pascal case here and in the json
           }
    
    [WebMethod]
     public static string GetCurrentTime(List<Data> lists)
     {
         return "text string" ;
     }
