    public IActionResult Login([FromForm] LoginModel entry) {
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }
        // access the username and password
        var username = entry.username;
        var password = entry.password;
        return Ok();
    }
