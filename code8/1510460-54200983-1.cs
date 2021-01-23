public class SomeQuery
{
    public string SomeParameter { get; set; }
    public int? SomeParameter2 { get; set; }
}
And then in controller just make something like that:
[HttpGet]
public IActionResult FindSomething([FromQuery] SomeQuery query)
{
    // Your implementation goes here..
}
Even better, you can create API model from:
[HttpGet]
public IActionResult GetSomething([FromRoute] int someId, [FromQuery] SomeQuery query)
to:
[HttpGet]
public IActionResult GetSomething(ApiModel model)
public class ApiModel
{
    [FromRoute]
    public int SomeId { get; set; }
    [FromQuery]
    public string SomeParameter { get; set; }
    [FromQuery]
    public int? SomeParameter2 { get; set; }
}
