    if (User.Identity.IsAuthenticated)
    {
        Claim claim = ((ClaimsIdentity)User.Identity).FindFirst("IsPersistent");
        bool IsPersistent = claim != null ? Convert.ToBoolean(claim.Value) : false;
    }
