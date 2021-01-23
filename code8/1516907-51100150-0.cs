    public async Task<IActionResult> GetRankings([FromBody] string cookie)
=>
  
    //1. make a model. MyCookie.cs
    class MyCookie{
       public string Cookie { get; set; }
    }
    //2. edit your parameter
    public async Task<IActionResult> GetRankings([FromBody] MyCookie cookie)
  
