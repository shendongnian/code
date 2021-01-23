    while (myFeed.paging != null && myFeed.paging.next != null)
                    {
                        NextPageURI = myFeed.paging.next;
                        var nextURL = GetNextPageQuery(NextPageURI, access_token);
                        dynamic nextPagedResult = await fb.GetTaskAsync(nextURL.GraphAPICall(appsecret_proof));
                        foreach (dynamic post in nextPagedResult.data)
                        {
                            postList.Add(DynamicExtension.ToStatic<FacebookPostViewModel>(post));
                        }
                    }
