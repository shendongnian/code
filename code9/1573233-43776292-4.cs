    public class ChartData
    {
       public string id { get; set; }
    }
    public class ChartData<T> : ChartData
    {
        public List<T> data { get; set; }
    
        public ChartData()
        {
        }
    
        public ChartData(string id, List<T> data)
        {
            this.id = id;
            this.data = data;
        }
    }
