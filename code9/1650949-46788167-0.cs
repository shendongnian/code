    FindItemsResults<Item> findResults = service.FindItems(WellKnownFolderName.SentItems, view);
    foreach (EmailMessage item in findResults)
    {
       PropertySet propertySet = new PropertySet(BasePropertySet.IdOnly);
	   item.Load(propertySet);
	   item.Delete(DeleteMode.HardDelete, true);
	}
