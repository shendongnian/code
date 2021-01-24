    public class Value
    {
        public String Name { get; set; }
    }
    ...
    [HttpPost("one")]
    public void Post([FromBody] Value value)
    {
        Console.WriteLine("got one");
    }
    
    [HttpPost("many")]
    public void Post([FromBody] Value[] value)
    {
        Console.WriteLine("got many");
    }
