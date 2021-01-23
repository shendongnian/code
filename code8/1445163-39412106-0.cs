    public class FindEmployeeBySearchTextQuery : IQuery<Employee>
    {
        public string Firstname{ get; set; }
    
        public string Lastname { get; set; }
    
        public string Email { get; set; }
    }
