    public IEnumerable<IPublishedContent> Whatever(IEnmerable<IPublishedContent> nodes, int count)
    {
        foreach(var node in nodes.Take(count))
        {
            var rolename = node.GetProperty("focusedUserGroup").Value.ToString();
            var username = umbraco.cms.businesslogic.member.Member.GetCurrentMember().Text;
            if (!string.IsNullOrEmpty(rolename))
            {
                var groups = rolename.Split(',');
                foreach (var group in groups)
                {
                    if (Roles.IsUserInRole(username, group))
                    {
                         yield return node; //yield return allows you to create a new enumerable inline
                         break;
                    }
                }
            }
        }
    }
