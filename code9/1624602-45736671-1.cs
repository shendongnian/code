	public async Task<Permissions> GetPermissions(HttpContext httpContext)
	{
		_httpContext = httpContext;
		// await result
		await PopulateUserIdAndIsAdminFlag();
		var permissions = new Permissions
		{
		  UserId = _userId,
		  IsAdministrator = _isAdministrator
		};
        // wrapping the result in Task is no longer necessary 
		return permissions;
	}
	// change void to Task
	private async Task PopulateUserIdAndIsAdminFlag()
	{
		if (!IsAuthenticated()) return;
		var username = _httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
		var user = await _userManager.FindByNameAsync(username);
		var roles = await _userManager.GetRolesAsync(user);
		_userId = user.Id;
		_isAdministrator = roles.Contains("Admin");
	}
