    public class ChartData<T>
    {
        public string id { get; set; }
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
