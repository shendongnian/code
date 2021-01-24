    [Authorize]
    public IActionResult Index()
    {
        return Content(this.User.Identity.Name);
    }
