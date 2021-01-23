    public IEnumerable<StatsModel> OpenSpreadsheetDocument(string filepath)
    {
         using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(filepath, false))
         {
              // Initialize sheetData here
              return sheetData.Elements<Row>().Select<StatsViewModel> 
              (row => {
                  var statsModel= new StatsViewModel ();
                  // Do your thing with statsModel here, using row.Elements<Cell>()
                  return statsModel;
              });
          }
    }
