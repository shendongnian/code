    public async Task<string[]> GetUserGroupsAsync(string UserName)
    {
        List<UserGroup> listGroup = await
            PostAsyncRestObject<List<UserGroup>, string>(
                "http://my_server/ServiceCommon.svc/GetUserGroups",
                UserName).ConfigureAwait(false);
        List<string> strGr = new List<string>();
        foreach (UserGroup ug in listGroup)
        {
            strGr.Add(ug.GroupName);
        }
        return strGr.ToArray();
    }
