    public class Employee
    {
        public int EmpCode { get; set; }
        public string FullName { get; set; }
    
        public override string ToString()
        {
            return String.Format("Employee Code : {0} \n Employee Full Name : {1}", this.EmpCode, this.FullName);
        }
    }
    
    public class EmployList
    {
        public List<Employee> EmployeeList = new List<Employee>();
        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder();
            foreach (var item in EmployeeList)
            {
                strBuilder.AppendLine(item.ToString());
            }
    
            return strBuilder.ToString();
        }
    }
