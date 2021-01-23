        public class Employee
        {
            public int EmpId { get; set; }
            public string EmpName { get; set; }
            // **Note** : I'm not using List<Address> data type for Address, instead of I want list of address in JSON string
            public List<AddressItems> Address { get; set; }
            public string AddressString { get; set; }
        }
        public class RootObject
        {
            public List<Employee> Employees { get; set; }
        }
        public class AddressItems
        {
            public int AddressId { get; set; }
            public string Address { get; set; }
        }
