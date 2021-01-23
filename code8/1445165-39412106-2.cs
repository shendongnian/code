    public class EmployeeViewModel()
    {
        private readonly IQueryHandler _queryHandler;
        public EmployeeViewModel(IQueryHandler queryHandler) 
        {
            _queryHandler = queryHandler;
        }
        public void PerformingSearch()
        {
            var query = new FindEmployeeBySearchTextQuery
            {
                Firstname = "John", 
                Lastname = "Doe",
                Email = "stack@has.been.over.flowed.com"
            };
         
            List<Employee> employees = _queryHandler.Handle(query);
        
            // .. Do further processing of the obtained data
        }
    }
