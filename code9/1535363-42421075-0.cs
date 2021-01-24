    // specify that we want to fill the IMessageSummary.Body and IMessageSummary.UniqueId fields...
    var items = folder.Fetch (ids, MessageSummaryItems.BodyStructure | MessageSummaryItems.UniqueId);
    foreach (var item in items) {
        foreach (var attachment in item.Attachments) {
            // 'octets' is just a fancy word for "number of bytes"
            var size = attachment.Octets;
    
            // download the individual attachment
            var entity = folder.GetBodyPart (item.UniqueId, attachment);
        }
    }
