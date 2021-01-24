    // await the task itself, after that do the UI stuff
    var collection = await Task.Run(() =>
    {
        // directly call the retrieve data
        return RetriveData(tempDataSet, firstTime);
    });
    // this code will resume on UI context
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
