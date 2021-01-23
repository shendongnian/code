    public async Task<List<string>> GetCurrentUserGroups(GraphServiceClient graphClient)
        {
            var totalGroups = new List<string>();
            var groups = await graphClient.Me.MemberOf.Request().GetAsync();
                
            while (groups.Count > 0)
            {
                foreach (Group g in groups)
                {
                    totalGroups.Add(g.DisplayName);
                }
                if (groups.NextPageRequest != null)
                {
                    groups = await groups.NextPageRequest.GetAsync();
                }
                else
                {
                    break;
                }
            }
            return totalGroups;
        }
