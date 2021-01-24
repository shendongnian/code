    public class EmployeeViewModel
    {
        public int EmployeeID { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeePosition { get; set; }
        public string EmployeePhoneNo { get; set; }
        public string EmployeeEmail { get; set; }
    	
    	public int DepartmentID { get; set; }
    	public string DepartmentName { get; set; }
    	public virtual Department Department { get; set; }
    }
