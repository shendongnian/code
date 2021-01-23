    List<SearchFilter> searchFilterCollection = new List<SearchFilter();
    searchFilterCollection.Add(new SearchFilter.ContainsSubstring(ItemSchema.Subject,"Words in Subject"));
    searchFilterCollection.Add(new SearchFilter.IsEqualTo(ItemSchema.HasAttachments,true));
    searchFilterCollection.Add(new SearchFilter.IsEqualTo(EmailMessageSchema.From,new EmailAddress("From@SendersDomain.com")));
    SearchFilter searchFilter = new SearchFilter.SearchFilterCollection(LogicalOperator.And,searchFilterCollection);
    
    ItemView view = new ItemView(50, 0, OffsetBasePoint.Beginning);
    view.OrderBy.Add(ItemSchema.DateTimeReceived, SortDirection.Descending);
    view.PropertySet = new PropertySet(BasePropertySet.IdOnly, ItemSchema.DateTimeReceived, ItemSchema.Attachments);
    view.Traversal = ItemTraversal.Shallow;
    FindItemsResults<Item> findResults = exService.FindItems(WellKnownFolderName.Inbox,searchFilter,view);
