    [HttpPost]
    public IActionResult Review([Bind(Include = "AdditionalComments,other properties")] Request requestVm)
    {
        // Some logic in here to save to db etc..
        return RedirectToAction("Thank_You");
    }
