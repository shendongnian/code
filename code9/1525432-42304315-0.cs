    public IActionResult DoSomething()
    {
        bool success = someWork();
        if (success)
        {
           // goto some action but not allow that action to be called directly
           return MyCrazySecretAction();
        }
        else
        {
           return View();
        }
    }
    private IActionResult MyCrazySecretAction()
    {
        return View();
    }
