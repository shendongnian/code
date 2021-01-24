    public class Data
    {
       public int Number {get; set;}
    }
    
    [HttpPost("method")]
    public string Method([FromBody] Data data)
    {
        return data.Number.ToString();
    }
