    [XmlRoot("Employee", Namespace = "http://www.testxmlns.com/employee")]
    public class EmployeeRoot
    {
        [XmlElement("Employee")]
        public Employee[] Employees { get; set; }
    }
    
    public class Employee
    {
        public string OtherElement { get; set; }
    }
