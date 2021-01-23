    public HeaderViewModel BuildHeaderViewModel(int? chainId, int? sheetId)
    {
        return BuildHeaderViewModel(chainId, sheetId, null);
    }
    
    public HeaderViewModel BuildHeaderViewModel(int? chainId, int? sheetId, int? fileId)
    {
        HeaderViewModel header = new HeaderViewModel();
    
        header.ChainName = db.Chains.Find(chainId).Name;
        header.SheetName = db.Sheets.Find(sheetId).Name;
        header.SheetDescription = db.Sheets.Find(sheetId).Description;
    
        if(fileId.HasValue)
        {
            var fileDetails = db.FileDetails.Find(fileId);
            header.SheetFileName = fileDetails.Name + fileDetails.Extension;
        }
        return header;
    }
