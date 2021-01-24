        const string imageUrl = "https://cdn.acumatica.com/media/2016/03/software-technology-industries-small.jpg";
        string path = Path.Combine(Path.GetTempPath(), Path.ChangeExtension(Path.GetTempFileName(), ".jpg"));
        
        // Download Image
        using (WebClient client = new WebClient())
        {
            client.DownloadFile(new Uri(imageUrl), path);
        }
    
        // ReadUploadFile function below
        byte[] data = ReadUploadFile(path);
    
        _itemsScreen.Import(new IN202500.Command[]
        {
            // Get Inventory Item
            new Value
            {
                Value = "D1",
                LinkedCommand = _itemsSchema.StockItemSummary.InventoryID,
            },
            _itemsSchema.Actions.Save,
            // Upload Inventory Item Image
            new Value
            {
                FieldName = Path.GetFileName(path),
                LinkedCommand = _itemsSchema.StockItemSummary.ServiceCommands.Attachment
            },
            _itemsSchema.Actions.Save
        },
        null,
        new string[][]
        {
            new string[]
            {
                // Image data
                Convert.ToBase64String(data)
            }
        },
        false,
        false,
        true);
                   
    public byte[] ReadUploadFile(string filePath)
    {
        byte[] filedata;
                
        using (FileStream file = File.Open(filePath,
                                            FileMode.Open,
                                            FileAccess.ReadWrite,
                                            FileShare.ReadWrite))
        {
            filedata = new byte[file.Length];
            file.Read(filedata, 0, filedata.Length);
        }
        if (filedata == null || filedata.Length == 0)
        {
            throw new Exception(string.Concat("Invalid or empty file: ", filePath));
        }
        return filedata;
    }
