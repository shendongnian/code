    [HttpPost("api/index")]
    public IActionResult IndexApi([FromBody]MyViewModel model)
        => IndexCore(model);
    [HttpPost("index")]
    public IActionResult Index(MyViewModel model)
        => IndexCore(model);
    protected IActionResult IndexCore(MyViewModel model)
    {
        // action code here
    }
