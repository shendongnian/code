    // ChangeEventsController
    [HttpGet("{id}")]
    public IActionResult Create(Guid id)
    // ProductsController
    [HttpGet]
    [Route("[action]/{id}")]
    public IActionResult CreateChangeEvent(Guid id)
