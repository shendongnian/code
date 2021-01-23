    persistantData = new Dictionary<string, object>();
                persistantData.Add(nameof(Version), Version);
                persistantData.Add(nameof(FileVersion), FileVersion);
                persistantData.Add(nameof(ScrollParameters), ScrollParameters);
                persistantData.Add(nameof(DefaultCellBackgroundColour), DefaultCellBackgroundColour);
                persistantData.Add(nameof(Columns), Columns);
                persistantData.Add(nameof(Rows), Rows);
                persistantData.Add(nameof(Cells), listOfCellData);
                persistantData.Add(nameof(Filename), FileName);
    private async Task SaveTheFileAsync(StorageFile file)
    {
        using (MemoryStream memoryStream = new MemoryStream())
        {
        var serializer = new DataContractSerializer(typeof(Dictionary<string, object>));
        serializer.WriteObject(memoryStream, persistantData); //Failed here
