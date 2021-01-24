    public class Res{
       public string statusCode {get;set;}
       public Data data {get; set;}
    }
     public class Data{
 	
	  public List<Item> items {get; set;}
	
      }
     public class Item{
	
	    public string id {get; set;}
	    public JsonData JsonData {get;set;}
	
    }
     public class JsonData{
	
	    public string name {get; set;}
	    public string from {get; set;}
     }
