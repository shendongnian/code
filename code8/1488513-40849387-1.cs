    public static string GetUserRole(this ClaimsPrincipal principal)
    {
        if (principal == null)
        {
            throw new ArgumentNullException(nameof(principal));
        }
        return principal.Claims.SingleOrDefault(c => c.Type == "role")?.Value;
    }
