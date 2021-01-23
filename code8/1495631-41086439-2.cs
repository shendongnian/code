    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; 
          set {
            if (condition == false)
              throw new Exception(" is Read Only !")
          }
        }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
    }
