    foreach (var group in jsonLines.Groups) ;
    {
        foreach (var item in group.Items)
        {
            var storage = new ItemData()
            {
                Title = item.Title,
                UniqueID = item.UniqueId,
                ImagePath = item.ImagePath,
                Group = item.Title
             };
             ItemData.Add(storage.UniqueID, storage);
             await FileIO.AppendTextAsync(fileFavourites, 
                    Item.UniqueId + "\r\n");
         }
     }
