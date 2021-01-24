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
        public List<string> categories { get; set; } = new List<string>();
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
        public List<double> data { get; set; } = new List<double>();
    }
    
    public class RootObject
    {
        public Chart chart { get; set; } = new Chart();
        public Title title { get; set; } = new Title();
        public XAxis xAxis { get; set; } = new XAxis();
        public YAxis yAxis { get; set; } = new YAxis();
        public Legend legend { get; set; } = new Legend();
        public PlotOptions plotOptions { get; set; } = new PlotOptions();
        public List<Series2> series { get; set; } = new List<Series2>();
    }
