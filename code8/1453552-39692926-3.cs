    [JsonObject(IsReference = true)]
    public class EmployeeReference
    {
        public string Name { get; set; }
        public EmployeeReference Manager { get; set; }
    }
