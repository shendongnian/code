    public class InputModel{
       public string FirstName{get;set;}
       public string LastName{get;set;}
    }
    [HttpPost]
    public IActionResult test([FromBody]InputModel model)...
