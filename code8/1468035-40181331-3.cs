    public Monster (string c_name, ...)
    {
        name = c_name; // could be null
        // so:
        name = c_name ?? string.Empty;
