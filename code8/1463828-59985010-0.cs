    using (var range = worksheet.Cells[1, 1, n, worksheet.Dimension.End.Column]) 
    {
             range.Style.Font.Bold = true;
    }
    
    //For understanding,   
    //Column Number = Worksheet.Dimension.End.Column   
    //Row Number = Worksheet.Dimension.End.Row
