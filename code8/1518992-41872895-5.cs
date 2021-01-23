    [HttpPost("[action]")]
    [Authorize]
    public async Task<IActionResult> Validate()
    {
        await HttpContext.RefreshLoginAsync();
    }
