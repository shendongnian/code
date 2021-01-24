    public string GetUserFullName(IIdentity identity)
                {
                    string claim = ((ClaimsIdentity)identity).FindFirstValue("UserFullName").ToString();
        
                    return claim;
                }
    
    GetUserFullName(User.Identity);
