    public ClaimsPrincipal User
    {
       get
       {
           return HttpContext?.User;
       }
    }
