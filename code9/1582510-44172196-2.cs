    IUserMemberOfCollectionWithReferencesPage memberOfGroups = await graphClient.Users["testnanyu@testbasic1.onmicrosoft.com"].MemberOf.Request().GetAsync();
                if (memberOfGroups?.Count > 0)
                {
                    foreach (var directoryObject in memberOfGroups)
                    {
                        // We only want groups, so ignore DirectoryRole objects.
                        if (directoryObject is Group)
                        {
                            Group group = directoryObject as Group;
                            items.Add(new ResultsItem
                            {
                                Display = group.DisplayName,
                                Id = group.Id
                            });
                        }
                    }
                }
