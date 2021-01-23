    //Get your Item list here
    var itemList = GetItemList();
    
    //Loop in the Item list to get the languages
    //Publish the item based on the languages
    foreach (var item in itemList)
    {
        var languageVersions = item.Languages;
        Sitecore.Publishing.PublishManager.PublishItem(item, targetDb, languageVersions, true, false);
    }
