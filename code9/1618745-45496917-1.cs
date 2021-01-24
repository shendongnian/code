    [HttpPost("/test/{rootId}/echo/{id}")]
    public IActionResult TestEcho(TestModel data)
    {
        return Json(new
        {
            data.Id,
            data.RootId,
            data.Name,
            data.Description,
            Errors = ModelState.IsValid ? null : ModelState.SelectMany(x => x.Value.Errors)
        });
    }
