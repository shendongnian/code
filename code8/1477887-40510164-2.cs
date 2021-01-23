    public IActionResult Sale()
    {
        return View();
    }
    @model WebApplication4.Models.Sale
    ...
    <customer asp-for="CustomerId" />
    public IActionResult Promotion()
    {
        return View(new Models.Promotion { CustomerId = "abc-123" });
    }
    @model WebApplication4.Models.Promotion
    ...
    <customer asp-for="CustomerId" />
