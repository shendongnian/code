    [AuthorizePermission(Permission.Foo, Permission.Bar)]
    public IActionResult Index()
    {
        return View();
    }
