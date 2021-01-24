    foreach (object item in mailItems)
    {
        // try casting to Outlook.MailItem first
        var obj = item as Outlook.MailItem;
        // check if the conversion works and UnRead property can be accessed as well
        if (item != null && item.UnRead == true)
        {
            // do something
        }
        else
        {
            // do something else
        }
    }
