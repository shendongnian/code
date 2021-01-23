    // EventsController
    [HttpGet(Name = "Get an event")]
    [Route("events/{id}")]
    public IActionResult Get([FromQuery] Guid id)
    // ProductsController
    [HttpGet(Name = "Get a product")]
    [Route("products/{id}")]
    public IActionResult Get([FromQuery] Guid id)
