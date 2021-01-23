    bool IsCondition(IPublishedContent n)
    {
        var rolename = n.GetProperty("focusedUserGroup").Value.ToString();
        var username = umbraco.cms.businesslogic.member.Member.GetCurrentMember().Text;
    
        if (!string.IsNullOrEmpty(rolename))
        {
            var groups = rolename.Split(',');
    
            foreach (var group in groups)
            {
                if (Roles.IsUserInRole(username, group))
                {
                     return true;
                }
            }
        }
        return false;
    }
