    private const string key = "RoleClaims"
    private bool HasClaim(string[] requiredClaims)
    {
        // Check the cache
        Dictionary<string, IEnumerable<string>> roleClaims = Cache.Get(key)
        if (roleClaims == null)
        {
            roleClaims = new Dictionary<string, IEnumerable<string>>();
            Cache.Set(key, roleClaims, 240);
        }
        foreach (var role in roleIds)
        {
            IEnumerable<string> claims;
            if (roleClaims.ContainsKey(role))
            {
                claims = roleClaims[role];
            }
            else
            {
                claims = db.RoleClaims.Where(roleIds == role).Select(x => x.Claim.Name);
                roleClaims.Add(role, claims)
            }
            if (claims.Any(x => requiredClaims.Contains(x)))
            {
                return true // exit
            }
        }
    return false;
    }
