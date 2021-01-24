    [Post("create")]  //<-- Matches POST api/identity/create
    [AllowAnonymous]
    public async Task<IActionResult> Create(string user) {
        var decodedUser = DecodeUser(user);
        var applicationUser = new ApplicationUser(new User
        {
            Id = Guid.NewGuid(),
            Name = decodedUser.Username,
            LastActive = DateTime.UtcNow
        });
        ISet<IdentityResult> result = await _userService.Add(applicationUser, decodedUser.Password);
        return Ok(result);
    }
