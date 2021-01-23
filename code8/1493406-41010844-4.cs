    using (Stream contentStream = await requestContent.ReadAsStreamAsync())
    {
        Workbook workbook = new Workbook(contentStream);
        Worksheet worksheet = workbook.Worksheets[0];
        int column = 0; // first column
        Cell lastCell = worksheet.Cells.EndCellInColumn((short)column);
        List<IAsyncResult> asyncResults = new List<IAsyncResult>();
        string xmlContent = ""; // assuming this is local
    
    
        for (int row = 0; row <= lastCell.Row; row++)
        {
            Cell cell = worksheet.Cells.GetCell(row, column);
            xmlContent += cell.StringValueWithoutFormat;
            if (((row > 0) && (row % rowsPerThread == 0)) || (rows == lastCell.Row))
            {
                var caller = new GenerateDelegate(Generate);
                asyncResults.Add(caller.BeginInvoke(xmlContent, null, null));
                xmlContent = "";
            }
        }
        // Wait for the threads
        asyncResults.ForEach(result => {
           while(result.IsCompleted == false) {
               Thread.Sleep(250);
           }
       });
    }
