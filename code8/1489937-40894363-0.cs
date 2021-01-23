    public async Task<IActionResult> Action(string parameter)
    {
        ViewBag.parameter = parameter;
        return View()
    }
