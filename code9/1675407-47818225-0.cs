    [Authorize]
    public async Task<IActionResult> MySecureAction()
    {
       _logger.LogDebug($"Logged in User is {HttpContext.User.Identity.Name}");
       return OK();
    }
