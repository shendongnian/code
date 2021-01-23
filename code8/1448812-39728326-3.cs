    var wi = HttpContext.Current.User.Identity as WindowsIdentity;
    if (wi != null)
    {
        var wp = new WindowsPrincipal(wi);
        List<string> groups = Constants.ADGroups(); // List of AD groups to test against
        foreach (var @group in groups)
        {
            Debug.WriteLine($"Searching for {@group}");
            if (wp.IsInRole(@group))
            {
                return true;
            }
        }
    }
