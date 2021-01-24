    [HttpPost]
    public async Task<object>ConfirmEmail([FromBody] UserInfo userInfo)
    {
    
    }
    Public Class UserInfo
    {
      public long userid {get; set;}
      public long code {get; set;}
    }
