    public sealed partial class MainPage : Page
    {
        private Random _random = new Random();
        public MainPage()
        {
            this.InitializeComponent();
            var data = new List<DataPoint>();         
            for (int i = 0; i < 3; i++)
            {
                data.Add(new DataPoint { Name = "Name" + i, Amount = _random.Next(10, 100) });              
            }
            DataChartNode charnode = new DataChartNode()
            {
                Title = "Hello",
                Data = data
            };          
            this.DataContext = charnode;     
        }
    }
    public class DataChartNode
    {
        public string Type { set; get; }
        public string Title { set; get; }
        public int Length { set; get; }
        public List<DataPoint> Data { set; get; }
    }
    public class DataPoint
    {
        public string Name { get; set; }
        public int Amount { get; set; }      
    }
