    public async Task<ActionResult> Index()
    {
         await DoSomethingAsync3().ConfigureAwait(false);
         return View();
    }
