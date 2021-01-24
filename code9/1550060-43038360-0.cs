    [HttpPost]
    [Authorize]
    public string GetMessage()
    {
        return "I'm a Member of StackOverflow" + 
            ((this.User != null) && (this.User.IsInRole("Admin"))) 
                ? "since 2010" : String.Empty;
    }
