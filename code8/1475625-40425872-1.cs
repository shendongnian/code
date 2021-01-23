    var query = SearchQuery.SubjectContains ("damian_mistrz_");
    var orderBy = new OrderBy[] { OrderBy.Subject };
    var uids = folder.Search (query);
    var items = folder.Fetch (uids, MessageSummaryItems.Envelope | MessageSummaryItems.UniqueId);
    
    items.Sort (orderBy);
    
    foreach (var item in items) {
        var message  = folder.GetMessage (item.UniqueId);
    
        // save the attachments...
    }
