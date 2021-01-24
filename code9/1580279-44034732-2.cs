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
    public class Tags
    {
        public EmployeeID __invalid_name__Employee ID { get; set; }
        public JobFamily __invalid_name__Job Family { get; set; }
    }
    public class User
    {
        public int id { get; set; }
        public string userName { get; set; }
        public Tags tags { get; set; }
    }
