            List<ResultsItem> items = new List<ResultsItem>();
            // Get group members. 
            IGroupMembersCollectionWithReferencesPage members = await graphClient.Groups[id].Members.Request().GetAsync();
            if (members?.Count > 0)
            {
                foreach (User user in members)
                {
                    // Get member properties.
                    items.Add(new ResultsItem
                    {
                        Properties = new Dictionary<string, object>
                        {
                            { Resource.Prop_Upn, user.UserPrincipalName },
                            { Resource.Prop_Id, user.Id }
                        }
                    });
                }
            }
