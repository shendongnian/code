    // ChangeEventsController
    [HttpGet(Name = "Get an event")]
    [Route("{id}")]
    public IActionResult Create(Guid id)
    // ProductsController
    [HttpGet(Name = "Get a product")]
    [Route("{id}")]
    public IActionResult CreateChangeEvent(Guid id)
