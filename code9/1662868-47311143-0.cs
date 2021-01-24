    var li = new ListItem();
    li.Fields.AdditionalData.Add("Title", "My New File Title");
    await gClient
        .Sites[mySIteId]
        .Drives[myDriveId]
        .Items[newifle.Id]
        .ListItem
        .Request()
        .UpdateAsync(li);
