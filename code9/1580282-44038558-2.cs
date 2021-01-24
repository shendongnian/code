    public class Rootobject
    {
        public int id { get; set; }
        public string userName { get; set; }
        public Tags tags { get; set; }
    }
    public class Tags
    {
        [JsonProperty(PropertyName = "Employee ID")]
        public EmployeeID EmployeeID { get; set; }
        [JsonProperty(PropertyName = "Job Family")]
        public JobFamily JobFamily { get; set; }
    }
    public class EmployeeID
    {
        public string name { get; set; }
        public string value { get; set; }
    }
    public class JobFamily
    {
        public string name { get; set; }
        public string value { get; set; }
    }
