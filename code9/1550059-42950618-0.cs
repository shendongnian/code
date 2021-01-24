    [HttpPost]
    public string GetMessage()
    {
        return "I'm a Member of StackOverflow" + User != null && User.IsInRole("Admin") ? "since 2010" : String.Empty;
    } 
