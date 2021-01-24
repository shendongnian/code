    void Main()
    {
      DateTime currentDate=DateTime.UtcNow.Date.AddDays(-30);
      var currentMonthData=Device_GameDevices
        .Where(x=>x.CreatedDate>=currentDate)
        .ToList();
    
      // Get total game list
      var gamesList=currentMonthData
        .Select(x=>x.GameName)
        .Distinct();
        .ToList();
