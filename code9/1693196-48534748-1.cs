    public IActionResult ActionMethod1(Model value)
    {
        return View(value);
    }
    public IActionResult ActionMethod2(int pageKind)
    {
        Model temp = new Model();
        if (pageKind == 1)
        {
            temp.modelStr = "Hi ASP.NET Core";
        }
        else
        {
            temp.modelStr = "error!";
        }
        return ActionMethod1(temp);
    }
