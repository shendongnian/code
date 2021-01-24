    [HttpGet]
    public IActionResult GetCompanies() {
        var json = "[{\"Name\":\"ABC\"},[{\"A\":\"1\"},{\"B\":\"2\"},{\"C\":\"3\"}]]";
        return Content(json, new MediaTypeHeaderValue("application/json"));
    }
