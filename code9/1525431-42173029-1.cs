    public IActionResult DoSomething()
    {
        bool success=someWork();
        if(success)
        {
            return ViewComponent("Success");
        }
        else
        {
            return View();
        }
    }
