            ActiveDirectoryClient activeDirectoryClient = new ActiveDirectoryClient(serviceRoot,
                    async () => await GetTokenForApplication());
            IList<string> groupMembership = new List<string>();
            IUser user = activeDirectoryClient.Users.Where(u => u.ObjectId.Equals(userObjectID)).ExecuteAsync().Result.CurrentPage.ToList().First();
            var userFetcher = (IUserFetcher)user;
            IPagedCollection<IDirectoryObject> pagedCollection = userFetcher.MemberOf.ExecuteAsync().Result;
            do
            {
                List<IDirectoryObject> directoryObjects = pagedCollection.CurrentPage.ToList();
                foreach (IDirectoryObject directoryObject in directoryObjects)
                {
                    if (directoryObject is Group)
                    {
                        var group = directoryObject as Group;
                        groupMembership.Add(group.DisplayName);
                    }
                }
                pagedCollection = pagedCollection.GetNextPageAsync().Result;
            } while (pagedCollection != null);
