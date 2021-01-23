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
