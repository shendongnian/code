                client.Context.MergeOption = MergeOption.AppendOnly;
                IPagedCollection<IUser> pagedCollection = await client.Users.Expand(d => d.MemberOf).ExecuteAsync();
                if (pagedCollection != null)
                {
                    do
                    {
                     
                        //loop the users and get the memberof information
                        pagedCollection = await pagedCollection.GetNextPageAsync();
                    } while (pagedCollection != null);
                }
