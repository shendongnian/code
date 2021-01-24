    public class Data
    {
       public int number {get; set;}
    }
    
    [HttpPost("method")]
    public string Method([FromBody] Data data)
    {
        return data.number.ToString();
    }
