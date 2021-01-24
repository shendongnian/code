    [Get] //<-- Matches GET api/identity
    [AllowAnonymous]
    public IActionResult Index() {
        var result = new Dictionary<string,string>
            {
                { "status", "live" }
            }.Serialize();
        return Ok(result);
    }
