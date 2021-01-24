    public IActionResult ActionMethod1()
    {
        var value = (Model)TempData["model"];
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
        TempData["model"] = temp;
        return RedirectToAction("ActionMethod1");
    }
