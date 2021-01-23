    public class Employee
    {
        public ObjectId Id { get; set; }
        public string BSN { get; set; }
        public string Name { get; set; }
        public EmployeeFunction Function { get; set; 
    }
    public class EmployeeFunction 
    {
        public string FunctionDesc { get; set; }
        public string MoreInfo { get; set; }
    }
