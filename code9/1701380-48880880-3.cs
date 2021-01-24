    public class Program
        {
            static void Main()
            {
                GetEmployeeInfoFromDatabase((e) => e.EmployeeEmail == "UserProvidedEmailAdderessGoesHere");
            }
    
            public EmployeeStandardInfoResponse static GetEmployeeInfoFromDatabase(Expression<Func<Employee,bool>> exprssion)
            {
               /* parse this exression to build query*/
               /* use as it is if using entity framework*/
            }
        }
    
        class Employee
        {
            public int EmployeeId { get; set; }
            public string EmployeeEmail { get; set; }
        }
    }
