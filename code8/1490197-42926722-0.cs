	string spreadsheetId = "1DD3zfGe6.......UtENHhnBwz0CA";
	
	//get sheet id by sheet name
    Spreadsheet spr = service.Spreadsheets.Get(spreadsheetId).Execute();
    Sheet sh = spr.Sheets.Where(s => s.Properties.Title == sheetName).FirstOrDefault();
    int sheetId = (int)sh.Properties.SheetId;
	
	//define cell color
    var userEnteredFormat = new CellFormat()
    {
        BackgroundColor = new Color()
        {
            Blue = 0,
            Red = 1,
            Green = (float)0.5,
            Alpha = (float)0.1
        },
        TextFormat = new TextFormat()
        {
            Bold = true,
			FontFamily = "your font family",
            FontSize = 12
        }
    };
	BatchUpdateSpreadsheetRequest bussr = new BatchUpdateSpreadsheetRequest();
	
	//create the update request for cells from the first row
	var updateCellsRequest = new Request()
    {
        RepeatCell = new RepeatCellRequest()
        {
            Range = new GridRange()
            {
                SheetId = sheetId,
                StartColumnIndex = 0,
                StartRowIndex = 0,
                EndColumnIndex = 28,
                EndRowIndex = 1
            },
            Cell = new CellData()
            {
                UserEnteredFormat = userEnteredFormat
            },
            Fields = "UserEnteredFormat(BackgroundColor,TextFormat)"
        }
    };
    bussr.Requests = new List<Request>();
    bussr.Requests.Add(updateCellsRequest);            
    bur = service.Spreadsheets.BatchUpdate(bussr, spreadsheetId);
    bur.Execute();
