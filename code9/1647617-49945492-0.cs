	[Fact]
	public async Task ShouldAllowIfScopeClaimWorkflowAdminIsPresent()
	{
		// Arrange
		var authorizationService = BuildAuthorizationService(services =>
		{
			services.AddAuthorization(options =>
			{
				options.AddPolicy("SomePolicyName", new WorkflowCreatePolicy().AuthorizationPolicy
			});
		});
		var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim("scope", "WorkflowAdmin") }));
		// Act
		var allowed = await authorizationService.AuthorizeAsync(user, "SomePolicyName");
		// Assert
		Assert.True(allowed.Succeeded);
	}
