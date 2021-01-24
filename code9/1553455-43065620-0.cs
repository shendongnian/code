    public class EmployeeInformation
    {
        public bool IsSuccess { get; set; }
        public List<EmployeeBasicDetails> EmployeeBasicDetails { get; set; }
    }
    public class EmployeeBasicDetails
    {
        public int UserId { get; set; }
        public string EmployeeId { get; set; }
        public string EmailId { get; set; }
        public string EmployeeName { get; set; }
    }
