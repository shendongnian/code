    public class Order
    {
        public List<List<double>> ParametersA { get; set; }
        public List<List<double>> ParametersB { get; set; }
    }
    
    var obj = JsonConvert.DeserializeObject<Dictionary<string, Order>>(json);
