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
      var chart=new RootObject
      {
        chart=new Chart{ type="bar"},
        title=new Title{ text="My title" },
        xAxis=new XAxis { categories=gamesList() },
        yAxis=new YAxis { min=0, title=new Title2 {text="Total Game Time"}},
        legend=new Legend {reversed=true},
        plotOptions=new PlotOptions { series=new Series {stacking="normal"}},
        series= ...
      }
    }
