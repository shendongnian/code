    public interface IEmployeeWithName
    {
         int EmployeeId { get; set; }
         string FirstName { get; set; }
         string MiddleName { get; set; }
         string LastName { get; set; }
    }
     interface IEmployeeWithContacts
    {
         int EmployeeId { get; set; }
         string EmailAddress { get; set; }
         string HomePhone { get; set; }
         string MobilePhone { get; set; }
    }
     interface IEmployeeWithNameEmail
    {
         int EmployeeId { get; set; }
         string FirstName { get; set; }
         string MiddleName { get; set; }
         string LastName { get; set; }
         string EmailAddress { get; set; }
    }
     interface IEmployee
    {
         int EmployeeId { get; set; }
         string FirstName { get; set; }
         string MiddleName { get; set; }
         string LastName { get; set; }
         string EmailAddress { get; set; }
         string HomePhone { get; set; }
         string MobilePhone { get; set; }
    }
        
    public class Employee : IEmployee, IEmployeeWithContacts, IEmployeeWithName, IEmployeeWithNameEmail
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
    }
    public class EmployeeFactory
    {
        private Employee GetEmployeeByID(int id)
        {
            // this would perform the lookup and populate the Employee object...
            return new Employee();
        }
        public IEmployeeWithName GetEmployeeName(int id)
        {
            // The return should contain only FirstName, MiddleName and LastName. 
            return GetEmployeeByID(id);
        }
        public IEmployeeWithContacts GetEmployeeContacts(int id)
        {
            // The return should contain only EmailAddress, HomePhone and MobilePhone. 
            return GetEmployeeByID(id);
        }
        public IEmployeeWithNameEmail GetEmployeeNameEmail(int id)
        {
            // The return should contain only FirstName, MiddleName, LastName and EmailAddress. 
            return GetEmployeeByID(id);
        }
        public IEmployee GetEmployee(int id)
        {
            // It should return the entire Employee object
            return GetEmployeeByID(id);
        }
    }
