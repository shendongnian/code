    public partial class Company : IIdentifiable
        {
            public IEnumerable<Employee> ActiveEmployees
            {
                get
                {
                   return Employees.Where(e => !e.User.AccountIsDisabled).Include(x=>x.User).ToList();
                }
            }
        }
