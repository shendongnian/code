    public partial class Company : IIdentifiable
        {
            public IEnumerable<Employee> ActiveEmployees
            {
                get
                {
                   return Employees.Include(x=>x.User).Where(e => !e.User.AccountIsDisabled).ToList();
                }
            }
        }
