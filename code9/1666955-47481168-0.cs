    [HttpGet("{id:long}")]
    public IActionResult Get(long id) {
        var repo = new customerRepository();
        customer model = repo.GetCustomerOnPhone(id);
        return Ok(model);
    }
