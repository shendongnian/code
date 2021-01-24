    @if(User.Identity.Name.Equals("Administrator"))
    {
        <span>Welcome, <strong>Administrator</strong></span>
    }
    else if(User.Identity.Name.Equals("Bob"))
    {
        <span>Welcome, <strong>Bob</strong></span>
    }
    
