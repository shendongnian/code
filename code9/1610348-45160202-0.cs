    private bool CheckAllowed(string roles)
    {
        foreach (var role in roles.Split(','))
        {
            if (HttpContext.Current.User.IsInRole(x))
                return true;
        }
        return false;
    }
