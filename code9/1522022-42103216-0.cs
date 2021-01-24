    // In controller
    public async Task SwapRole([FromBody]RoleSwapRequestDto dto)
    {
        await _service.SwapRole(
            User,
            dto.RoleName
        );
        return await AddCookieToResponse();
    }
    private async Task AddCookieToResponse()
    {
        // Make your token however your app does this (generic dotnet core stuff.)
        var response = await _tokenService.RegenToken(User);
        if (response.Data != null && response.Data.Authenticated && response.Data.TokenExpires.HasValue)
        {
            Response.Cookies.Append(AuthToken, response.Data.Token, new CookieOptions
            {
                HttpOnly = false,
                Expires = response.Data.TokenExpires.Value
            });
        }
        return response;
    }
    
    /// inside _service
    public async Task SwapRole(ClaimsPrincipal claimsPrincipal, string X)
    {
        var currentUser = await UserManager.GetUserAsync(claimsPrincipal);
        var roles = await UserManager.GetRolesAsync(currentUser);
        await UserManager.RemoveFromRolesAsync(currentUser, roles);
        await UserManager.AddToRoleAsync(currentUser, X);
        await SignInManager.RefreshSignInAsync(currentUser);
    }
