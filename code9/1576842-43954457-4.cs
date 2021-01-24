    var wb = new XLWorkbook(@"C:\Users\passp\Documents\test.xlsx", XLEventTracking.Disabled);
    var sheet = wb.Worksheet("Sheet1");
    
    var sheet2 = wb.Worksheet("Sheet2");
    sheet2.Clear();
    	
    sheet.RowsUsed()
    	.Where(r => !r.IsEmpty())
    	.Select((r, index) => new { Row = r, Index = index + 1} )
    	.ForEach(r =>
    	{
    		var newRow = sheet2.Row(r.Index);
    			
    		r.Row.CopyTo(newRow);
    	}
    );
    
    wb.Save();
