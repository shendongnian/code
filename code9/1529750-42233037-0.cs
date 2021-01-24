    public string CreateWorkItem(HttpContext context, string xml)
    {
        var username = context.Current.User.Identity.Name;
        ...
    }
