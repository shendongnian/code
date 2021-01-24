    protected void DeleteMessage(ImapClient imap, IMailFolder mailFolder, UniqueId uniqueId)
    {
        if (_account.HostName.Equals("imap.gmail.com"))
        {
            IList<IMessageSummary> summaries = mailFolder.Fetch(new List<UniqueId>() { uniqueId }, MessageSummaryItems.GMailMessageId);
            if (summaries.Count != 1)
            {
                throw new Exception("Failed to find the message in the mail folder.");
            }
            mailFolder.MoveTo(uniqueId, imap.GetFolder(SpecialFolder.Trash));
            mailFolder.Close(true);
            IMailFolder trashMailFolder = imap.GetFolder(SpecialFolder.Trash);
            trashMailFolder.Open(FolderAccess.ReadWrite);
            SearchQuery query = SearchQuery.GMailMessageId(summaries[0].GMailMessageId.Value);
            IList<UniqueId> matches = trashMailFolder.Search(query);
            trashMailFolder.AddFlags(matches, MessageFlags.Deleted, true);
            trashMailFolder.Expunge(matches);
            trashMailFolder.Close(true);
            mailFolder.Open(FolderAccess.ReadWrite);
        }
        else
        {
            mailFolder.SetFlags(uniqueId, MessageFlags.Deleted, true);
            mailFolder.Expunge();
        }
    }
