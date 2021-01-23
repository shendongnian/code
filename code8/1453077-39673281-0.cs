    public IActionResult Index()
    {
        IList<Customer> customers = _ctx.Reviews.GetCustomers().ToList();
    
        // The result is converted to List using method ToList()
        return View(customers.Select(c => Mapper.Map<CustomerViewModel>(c)).ToList());
    }
