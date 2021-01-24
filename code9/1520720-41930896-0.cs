    [HttpGet]
    [Route("api/employees")]
    public IHttpActionResult Index()
    {
        IEnumerable<Employee> employees = ...
        Employee employee = employees.FirstOrDefault();
        return this.Ok(employee);
    }
