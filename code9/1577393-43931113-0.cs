    public class JsonResult{
   
    [JsonProperty(Name="key-name")]
       public string KeyName{get;set;}
    }
    
    var result = _context.data.Select(d => new JsonResult
    {
        KeyName = x.name
    });
    return Json(new {result = result});
