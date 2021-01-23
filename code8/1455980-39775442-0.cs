    public static bool CanAccess(int[] roleIDs, APIActionRoute apiActionRoute)
    {
        return _APIRights.Where(x => roleIDs.Contains(x.Key))
            .SelectMany(x => x.Value)
            .Any(a => a.ActionRoute == apiActionRoute);
    }
