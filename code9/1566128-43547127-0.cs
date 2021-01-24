    private void CheckForEmptyRow(WorkbookPart wbp, string sheetId)
    {
       Sheet sheet = wbp.Workbook.Descendants<Sheet>().FirstOrDefault(s => s.Id == sheetId);
       WorksheetPart wsp = (WorksheetPart).(wbp.GetPartById(sheetId));
       IEnumerable<SheetData> sheetData = wsp.Worksheet.Elements<SheetData>();
       bool isRowEmpty = false;
       foreach (SheetData SD in sheetData)
       {
          IEnumerable<Row> row = SD.Elements<Row>(); // Get the row IEnumerator
          
          if (row == null)
          {
              isRowEmpty = true;
              break;
          }
       }
       if (isRowEmpty)
       {
           sheet.Remove();
           wbp.DeletePart(wsp);
       }
    }
