    [HttpPost]
    public IActionResult CreateTemplate([FromForm] string name, 
                                        [FromServices] IModelFactory factory)
    {
        var item = factory.CreateTechnicalTaskTemplate(name);
        repo.Templates.Add(item);
        return View(nameof(TemplatesList));
    }
