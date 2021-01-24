    [Authorize(Policy = "CompanyStaffOnly")]
    public IActionResult SomeAction()
    {
        // ...
    }
