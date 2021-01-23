    if (client.Capabilities.HasFlag (ImapCapabilities.Sort)) {
        var query = SearchQuery.SubjectContains ("damian_mistrz_");
        var orderBy = new OrderBy[] { OrderBy.Subject };
        foreach (var uid in folder.Sort (query, orderBy) {
            var message = folder.GetMessage (uid);
        
            // save attachments...
        }
    }
