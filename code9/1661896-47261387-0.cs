    SearchFilter sf = new SearchFilter.IsEqualTo(ItemSchema.ItemClass, "IPM.Configuration.OWA.UserOptions");
    ItemView iv = new ItemView(1);
    iv.Traversal = ItemTraversal.Associated;
    FindItemsResults<Item> fiResults = Root.FindItems(sf, iv);
    UserConfiguration OWAConfig  =null;
    if (fiResults.Items.Count == 0)
    {
       OWAConfig = new UserConfiguration(service);
       OWAConfig.Save("OWA.UserOptions", Root.ParentFolderId);                
    }
