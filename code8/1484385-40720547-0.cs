           public class Employee
          {
            public string Name { get; set; }
            public string Department { get; set; }
          }
        public class EmployeeDepartMentList
        {
            public string DepartMentName {get;set; }
            public List<Employee> EmployeeList { get; set; }
        }
        public class FinalResult
        {
            public List<EmployeeDepartMentList> GetEmployeesByDepartment()
            {
                List<Employee> EmployeeList = new List<Employee>();
                var Model = EmployeeList.Select(x => x.Department).Distinct().Select(x => new EmployeeDepartMentList
                {
                    DepartMentName = x,
                    EmployeeList = EmployeeList.Where(y => y.Department == x).ToList()
                }).ToList();
                return Model;
            }
           
        }
