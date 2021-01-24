    public class DataSource
    {
        public string[] result { get; set; }
    
        public DataSource()
        {
            result = webservice.salesOrderList(apikey, null);
        }
    }
