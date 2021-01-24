    [HttpGet]
    public IActionResult Profiler()
    {
        return View(new MainPageModel(profile));
    }
    
    [HttpPost]
    public IActionResult Profiler(MainPageModel viewModel)
    {
        if(viewModel.Profile != null )
        {
            // Save profile
        }
        else if(viewModel.Image != null)
        {
            // Save image
        }
    }
