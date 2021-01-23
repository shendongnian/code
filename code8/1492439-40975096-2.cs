    ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
            service.AutodiscoverUrl("Deepak.kothari@domain.com");
            List<SearchFilter> searchFilterCollection = new List<SearchFilter>();
            searchFilterCollection.Add(new SearchFilter.ContainsSubstring(ItemSchema.Subject, "AccessCode"));
            SearchFilter searchFilter = new SearchFilter.SearchFilterCollection(LogicalOperator.Or, searchFilterCollection.ToArray());
            ItemView view = new ItemView(50);
            view.PropertySet = new PropertySet(BasePropertySet.IdOnly, ItemSchema.Subject, ItemSchema.DateTimeReceived){ RequestedBodyType = BodyType.Text };
            view.OrderBy.Add(ItemSchema.DateTimeReceived, SortDirection.Descending);
            view.Traversal = ItemTraversal.Shallow;
            FindItemsResults<Item> findResults = service.FindItems(WellKnownFolderName.Inbox, searchFilter, view);
            foreach (Item myItem in findResults.Items)
            {
                myItem.Load();
                if (myItem is EmailMessage)
                {
                    Console.WriteLine(HttpUtility.HtmlEncode((myItem as EmailMessage).Body));
                }
                else if (myItem is MeetingRequest)
                {
                    Console.WriteLine((myItem as MeetingRequest).Subject);
                }
                else
                {
                    // Else handle other item types.
                }
