    public class Eligibility
    {
        public string type { get; set; }
        public List<string> onDates { get; set; }
    }
    public class Loads
    {
        public int people { get; set; }
    }
    public class Location
    {
        public string address { get; set; }
    }
    public class TimeWindow
    {
        public int startSec { get; set; }
        public int endSec { get; set; }
    }
    public class CustomFields
    {
        public string myCustomField { get; set; }
        public string orderId { get; set; }
    }
    public class Delivery
    {
        public Location location { get; set; }
        public List<TimeWindow> timeWindows { get; set; }
        public string notes { get; set; }
        public int serviceTimeSec { get; set; }
        public List<object> tagsIn { get; set; }
        public List<object> tagsOut { get; set; }
        //this field will be Dictionary...
        public CustomFields customFields { get; set; }
    }
    public class Order
    {
        public string name { get; set; }
        public Eligibility eligibility { get; set; }
        public object forceVehicleId { get; set; }
        public int priority { get; set; }
        public Loads loads { get; set; }
        public Delivery delivery { get; set; }
    }
    public class OrderRequest
    {
        public List<Order> orders { get; set; }
    }
    public class OrderResponse
    {
        public string requestId { get; set; }
    }
