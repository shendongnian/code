    foreach(var outer in responseList)
    {
    foreach (var middle in (Dictionary<string, object>) outer.Value)
    {
         foreach (var inner in (Dictionary<string, string>) middle.Value)
         {
           Jsondata data = new Jsondata();
           data.href = inner["href"]; 
         }      
    }
    }
    public class Jsondata
    {
     public string href { get; set; }
     public string type { get; set; }
     public string resource{ get; set; }
    }
