    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        // **Note** : I'm not using List<Address> data type for Address, instead of I want list of address in JSON string
        [JsonConverter(typeof(RawConverter))]
        public string Address { get; set; }
    }
    public class RootObject
    {
        public List<Employee> Employees { get; set; }
    }
