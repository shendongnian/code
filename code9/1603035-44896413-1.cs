       public async Task<ActionResult> Index()
            {
                await getResultAsync();
                return View();
            }
