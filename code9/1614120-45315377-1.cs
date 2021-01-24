    var identity = HttpContext.User.Identity as ClaimsIdentity;
    if (identity != null)
    {
        IEnumerable<Claim> claims = identity.Claims; 
        // or
        identity.FindFirst("ClaimName").Value;
    }
