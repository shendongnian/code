         ItemView ivew = new ItemView(3);
      service.TraceEnabled = true;
      ExtendedPropertyDefinition PidTagInternetMessageId = new ExtendedPropertyDefinition(4149, MapiPropertyType.String);
      SearchFilter sf = new SearchFilter.IsEqualTo(PidTagInternetMessageId, MessageID);
      FindItemsResults<Item> iCol = service.FindItems(WellKnownFolderName.Inbox, sf, ivew);
      foreach (Item item in iCol.Items)
      {
        Console.WriteLine(item.Subject);
      }
