    var wb = new XLWorkbook(@"C:\Users\passp\Documents\test.xlsx");
    var sheet = wb.Worksheet("Sheet1");
    sheet.Clear();
    
    for (int i = 1; i < 50000; i+=2)
    {
    	var row = sheet.Row(i);
    
    	for (int j = 1; j < 20; j += 2)
    	{
    		row.Cell(j).Value = i * j;
    	}
    }
   
