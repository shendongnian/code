    public static string GetUserFullName(this IIdentity identity)
            {
                string claim = ((ClaimsIdentity)identity).FindFirstValue("UserFullName").ToString();
    
                return claim;
            }
