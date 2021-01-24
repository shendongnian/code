    /// <summary>
	///     Extracts login info out of an external identity
	/// </summary>
	/// <param name="manager"></param>
	/// <returns></returns>
	public static async Task<ExternalLoginInfo> GetExternalLoginInfoAsync(this IAuthenticationManager manager)
	{
		if (manager == null)
		{
			throw new ArgumentNullException("manager");
		}
		return AuthenticationManagerExtensions.GetExternalLoginInfo(await TaskExtensions.WithCurrentCulture<AuthenticateResult>(manager.AuthenticateAsync("ExternalCookie")));
	}
