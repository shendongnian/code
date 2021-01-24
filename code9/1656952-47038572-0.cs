    /// <summary>
    /// Extension method for authenticate.
    /// </summary>
    /// <param name="context">The <see cref="HttpContext"/> context.</param>
    /// <param name="scheme">The name of the authentication scheme.</param>
    /// <returns>The <see cref="AuthenticateResult"/>.</returns>
    public static Task<AuthenticateResult> AuthenticateAsync(this HttpContext context, string scheme) =>
        context.RequestServices.GetRequiredService<IAuthenticationService>().AuthenticateAsync(context, scheme);
