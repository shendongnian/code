        var defSheet = Service.Spreadsheets.Get(baseUrl).Execute().Sheets.First(x => x.Properties.Title.Equals("OldSheet"));
        var newSheet = new Request
        {
            DuplicateSheet = new DuplicateSheetRequest
        	{
        	    SourceSheetId = defSheet.Properties.SheetId,
        		NewSheetName = "NewSheet",
        		InsertSheetIndex = 1
        	}
       };
       var y = new BatchUpdateSpreadsheetRequest { Requests = new List<Request> { newSheet } };
       Service.Spreadsheets.BatchUpdate(y, baseUrl).Execute();
