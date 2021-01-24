            // Update a group.
            // This snippet changes the group name. 
            // This snippet requires an admin work account. 
            public async Task<List<ResultsItem>> UpdateGroup(GraphServiceClient graphClient, string id, string name)
            {
                List<ResultsItem> items = new List<ResultsItem>();
                IDictionary<string, object> extensionInstance = new Dictionary<string, object>();
                extensionInstance.Add(extensionIDYouGet, new MyDBExtensionClass(1213));
                // Update the group.
                await graphClient.Groups[id].Request().UpdateAsync(new Group
                {
                    DisplayName = Resource.Updated + name,
                    AdditionalData= extensionInstance
                });
    
                items.Add(new ResultsItem
                {
    
                    // This operation doesn't return anything.
                    Properties = new Dictionary<string, object>
                    {
                        { Resource.No_Return_Data, "" }
                    }
                });
                return items;
            }
