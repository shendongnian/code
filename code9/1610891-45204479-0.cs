    public string UserId
    {
        get
        {
            var principal = this.User as ClaimsPrincipal;
            return principal.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
