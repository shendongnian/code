    public class RootObject
    {
    	public Dictionary<string, Route> Routes { get; set; }
    	public Orders orders { get; set; }
    	public Vehicles vehicles { get; set; }
    	public Depots depots { get; set; }
    	public Drivers drivers { get; set; }
    }
    public class TrackingData
    {
        public string driverId { get; set; }
        public string vehicleId { get; set; }
        public int timeInSec { get; set; }
        public List<int> timeInLatLng { get; set; }
        public int timeOutSec { get; set; }
        public List<int> timeOutLatLng { get; set; }
        public string status { get; set; }
        public int statusSec { get; set; }
        public List<int> statusLatLng { get; set; }
        public int timeInDetectedSec { get; set; }
        public object timeInDetectedLatLng { get; set; }
        public int timeOutDetectedSec { get; set; }
        public object timeOutDetectedLatLng { get; set; }
        public object pods { get; set; }
    }
    
    public class Step
    {
        public string type { get; set; }
        public int idleTimeSec { get; set; }
        public int perStopTimeSec { get; set; }
        public int arrivalSec { get; set; }
        public int startSec { get; set; }
        public int endSec { get; set; }
        public int driveToNextSec { get; set; }
        public int distanceToNextMt { get; set; }
        public string displayLabel { get; set; }
        public string orderId { get; set; }
        public TrackingData trackingData { get; set; }
    }
    
    public class Route
    {
        public string id { get; set; }
        public int revision { get; set; }
        public string date { get; set; }
        public string vehicleId { get; set; }
        public string driverId { get; set; }
        public List<Step> steps { get; set; }
    }
