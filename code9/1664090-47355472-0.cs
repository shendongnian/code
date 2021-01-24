    namespace Intranet.Models
    {
        public class AddCustomers
        {
            public int AddCustomersID { get; set; }
            public string CompanyName { get; set; }
            public EmployeeInfo EmployeeInfo { get; set; }
            public ContactInfo ContactInfo { get; set; }
            ...
        }
        public class EmployeeInfo
        {
            public int EmployeeInfoID { get; set; }
            public string Forename { get; set; }
            ...
        }
    
        public class ContactInfo
        {
            public int ContactInfoID { get; set; }
            public string Code { get; set; }
            ...
        }        
    }
