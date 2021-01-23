    //For specific cell range
    using (var range = worksheet.Cells[From Row, From Column, To Row, To Column]) 
    {
             range.Style.Font.Bold = true;
    }
    //For understanding,   
    //Column Number = Worksheet.Dimension.End.Column   
    //Row Number = Worksheet.Dimension.End.Row
    // OR  
    //For Whole row 
    using(var package = new OfficeOpenXml.ExcelPackage())
    {
        worksheet.Row(5).CustomHeight = false;
        worksheet.Row(5).Height = 50;
        worksheet.Row(5).Style.Font.Bold = true ;
        worksheet.Row(5).Style.WrapText = true;
    }
