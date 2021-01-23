    [HttpPost]
    public IActionResult Post([FromBody]DataModel model)
    {
        return Ok();
    }
    public class DataModel {
         public string FirstName {get; set;}
    }
