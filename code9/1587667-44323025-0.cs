    public class LogListVM {
      public int year { get; set; } 
      public int month { get; set; } 
      public string app { get; set; } 
      public IEnumerable<string> levels { get; set; } 
    }
    [HttpPost]
    [Route("api/home/GetLogList")]
    public async Task<IEnumerable<Log>> GetLogList(LogListVM params)
    {
      using (var client = new HttpClient())
      {
        var refreshedLogs = await GetLogList(client, params.year, params.month, params.app, null);
        return refreshedLogs;
      }
    }
