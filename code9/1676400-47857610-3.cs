    public class SomeModelClass
    {
       public string data { get; set; }
    }
    
    [HttpPost]
    [Route("api/YourAPIName")]
    public HttpResponseMessage YourMethod([FromBody] SomeModelClass modelClass)
    {
        //perform logic and return a HTTP response
    }
