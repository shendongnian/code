    // Instantiate the item view with the number of items to retrieve from the Contacts folder.
            ItemView view = new ItemView(9999);
             // Request the items in the Contacts folder that have the properties that you selected.
            FindItemsResults<Item> contactItems = service.FindItems(WellKnownFolderName.Contacts, view);
            string groupId = string.Empty;
            List<ItemId> groupItemIds = new List<ItemId>();
            // Loop through all contacts 
            foreach (Item item in contactItems)
            {
                //Check to see if ContactGroup
                if (item is ContactGroup)
                {
                    //Get the contact group
                    ContactGroup contactGroup = item as ContactGroup;
                    groupItemIds.Add(item.Id);//Using to send an email by item id, can classify by DisplayName etc..
                }
            }
