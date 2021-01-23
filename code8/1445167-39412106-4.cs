    public class FindEmployeeBySearchTextQueryHandler
        : IQueryHandler<FindEmployeeBySearchTextQuery, List<Employee>>
    {
        private readonly IDbContext db;
     
        public FindEmployeeBySearchTextQueryHandler(IDbContext db)
        {
            this.db = db;
        }
     
        public List<Employee> Handle(FindEmployeeBySearchTextQuery query)
        {
            return (
                from employee in this.db.employees
                where employee.FirstName.Contains(query.FirstName) ||
                      employee.LastName.Contains(query.LastName) ||
                      employee.Email == query.Email
                select employee )
                .ToList();
        }
    }
