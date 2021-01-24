    public string Roles 
    {
        get 
        { 
            if(RoleList == null 
               || RoleList.Count == 0)
            {
                return null;
            }
            return string.Join(",", RoleList);
        }
    }
