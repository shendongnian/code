    [HttpPost]
    [AllowAnonymous]
    [IgnoreAntiforgeryToken]
    public ActionResult Index()
    {
        if (!User.Identity.IsAuthenticated)
        {
            return NewIndex();
        }
        // rest of action
    }
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public ActionResult NewIndex()
    {
        // body of new action
    }
