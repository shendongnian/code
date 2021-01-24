    public class Chart
    {
        public string type { get; set; }
    }
    
    public class Title
    {
        public string text { get; set; }
    }
    
    public class XAxis
    {
        public List<string> categories { get; set; } 
    }
    
    public class Title2
    {
        public string text { get; set; }
    }
    
    public class YAxis
    {
        public int min { get; set; }
        public Title2 title { get; set; }
    }
    
    public class Legend
    {
        public bool reversed { get; set; }
    }
    
    public class Series
    {
        public string stacking { get; set; }
    }
    
    public class PlotOptions
    {
        public Series series { get; set; }
    }
    
    public class Series2
    {
        public string name { get; set; }
        public List<double> data { get; set; } 
    }
    
    public class RootObject
    {
        public Chart chart { get; set; }
        public Title title { get; set; }
        public XAxis xAxis { get; set; }
        public YAxis yAxis { get; set; }
        public Legend legend { get; set; }
        public PlotOptions plotOptions { get; set; }
        public List<Series2> series { get; set; } 
    }
    
    void Main()
    {
      var Device_GameDevices = new[] {
        new {ID=1,CreatedDate=DateTime.Parse("8/23/2017 06:07:30"),DeviceID="Desktop12",EndTime=DateTime.Parse("8/23/2017 06:06:30"),GameName="CyberGunner",StartTime=DateTime.Parse("8/23/2017 06:03:45")},
        new {ID=2,CreatedDate=DateTime.Parse("8/23/2017 07:14:01"),DeviceID="A12"      ,EndTime=DateTime.Parse("8/23/2017 11:14:01"),GameName="Marriage"   ,StartTime=DateTime.Parse("8/23/2017 07:14:01")},
        new {ID=3,CreatedDate=DateTime.Parse("8/23/2017 07:14:02"),DeviceID="A12"      ,EndTime=DateTime.Parse("8/23/2017 08:14:01"),GameName="Marriage"   ,StartTime=DateTime.Parse("8/23/2017 07:14:02")},
        new {ID=4,CreatedDate=DateTime.Parse("8/23/2017 09:14:01"),DeviceID="A12"      ,EndTime=DateTime.Parse("8/23/2017 09:14:01"),GameName="Chess"      ,StartTime=DateTime.Parse("8/23/2017 07:14:03")},
        new {ID=5,CreatedDate=DateTime.Parse("8/23/2017 07:14:03"),DeviceID="A12"      ,EndTime=DateTime.Parse("8/23/2017 10:14:01"),GameName="Marriage"   ,StartTime=DateTime.Parse("8/23/2017 07:14:03")},
        new {ID=6,CreatedDate=DateTime.Parse("8/23/2017 09:57:28"),DeviceID="B12"      ,EndTime=DateTime.Parse("8/23/2017 10:57:28"),GameName="Marriage"   ,StartTime=DateTime.Parse("8/23/2017 09:57:28")},
      };
      DateTime currentDate=DateTime.UtcNow.Date.AddDays(-30);
      var currentMonthData=Device_GameDevices
        .Where(x=>x.CreatedDate>=currentDate)
        .ToList();
    
      // Get total game list
      var gamesList=currentMonthData
        .Select(x=>x.GameName)
        .Distinct()
        .ToList();
    
      var chart=new RootObject
      {
        chart=new Chart{ type="bar"},
        title=new Title{ text="My title" },
        xAxis=new XAxis { categories=gamesList },
        yAxis=new YAxis { min=0, title=new Title2 {text="Total Game Time"}},
        legend=new Legend {reversed=true},
        plotOptions=new PlotOptions { series=new Series {stacking="normal"}},
        series=currentMonthData
          .GroupBy(d=>new {d.DeviceID,d.GameName})
          .Select(d=>new {
            DeviceID=d.Key.DeviceID,
            GameName=d.Key.GameName,
            HoursPlayed=d.Sum(x=>(x.EndTime - x.StartTime).TotalMinutes)/60
          })
          .GroupBy(d=>d.DeviceID)
          .Select(d=>new Series2 {
            name=d.Key,
            data=gamesList
    		  .GroupJoin(d,a=>a,b=>b.GameName,(a,b)=>new {GameName=a,HoursPlayed=b.Sum(z=>z.HoursPlayed)})
    		  .OrderBy(x=>gamesList.IndexOf(x.GameName))
    		  .Select(x=>x.HoursPlayed)
              .ToList()
    	  }).ToList()
      };
      chart.Dump();
    }
