    // await the task itself, after that do the UI stuff
    var collection = await Task.Run(() =>
    {
        // <-- GetData should return a collection of objects
        return GetData(true);
    });
    foreach (var item in collection)
    {
        var control = new UC_InboxControl(row, uC_Inbox);
        if (!uC_Inbox.mnuUnreadChat.IsChecked)
        {
            inboxControlCollection.Add(control);
        }
        else
        {
            inboxUnreadOnlyControlCollection.Add(control);
        }
    }
