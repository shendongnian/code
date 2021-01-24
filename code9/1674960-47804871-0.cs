            ExtendedPropertyDefinition eDef = new ExtendedPropertyDefinition(0x300B, MapiPropertyType.Binary);    
            ItemView iv = new ItemView(1000);
            SearchFilter sf = new SearchFilter.IsEqualTo(eDef ,Convert.ToBase64String(searchval));
            FindItemsResults<Item> fiItems = Folder.FindItems(sf, iv);
            
