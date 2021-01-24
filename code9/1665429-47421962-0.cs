    public class AddCustomerViewModel
    {
        public AddCustomerViewModel()
        {
             Employees = new List<EmployeeInfo>();
             ContactInfo = new ContactInfo;
        }
        public int AddCustomersID { get; set; }
        public string CompanyName { get; set; }
        public string Status { get; set; }
        // Contact info - If there is only 1, you could just add the properties to the ViewModel
        public ContactInfo ContactInfo { get; set; }
        // Related employee:
        public List<EmployeeInfo> Employees { get; set; }
    }
