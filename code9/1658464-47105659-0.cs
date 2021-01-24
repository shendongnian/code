    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Get([FromBody] LoginViewModel model)
    {
        return Json(model);
    }
