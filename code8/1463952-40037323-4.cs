    private static Group GetGroupByDisplayName(Skype client, string groupDisplayName)
    {
        foreach (Group g in client.Groups)
        {
            if (g.DisplayName == groupDisplayName)
            {
                return g;
            }
        }
        return null;
    }
