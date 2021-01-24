    ///
    /// Merged Row Model Psuedo Code
    ///
    MergedRow {
        // Fields merged across rows
        ...
        // list of rows with non merged data
        list<indvidulerow> data
    }
    ///
    /// Code to find rows with merged cells.
    ///
    
    ... // worksheet prep
    var mergedRows = new Dictionary<int, MergedRow>();
    ... // begin generating rows
    ...
    // code generating the first merged cell of a row
    using (var r = sheet.Cells[rowIndex, 1, rowIndex+ mergedRow.Data.Count - 1, 1]){
    if(mergedRow.Data.count>1){
        r.Merge=true;
        mergedRows.Add(rowIndex, mergedRow);
    }
    ... // code for remainder of of cell
    ///
    /// Code to Resize Rows. Making last row expand enough to see 
    /// all content in merged cells
    ///
    foreach (var firstRowIndex in mergedRows.Keys){
        var numRowsMerged = mergedRows[firstRowIndex].Data.Count;
        var columnHeights = new List<ColumnHeightCalcModel>();
        for (var colIndex = 0; colIndex < totalColumns; colIndex++){
            var calcModel = new ColumnHeightCalcModel();
            var combinedHeight = 0.0;
            var lastRowHeight = 0.0;
            for (rowIndex = 0; rowIndex < numRowsMerged; rowIndex++){
                var cell = sheet.Cells[firstRowIndex + rowIndex, colIndex + 1];
                var cellText = cell.Text;
                var cellmerged = cell.Merge;
                var cellWidth = sheet.Column(colIndex+1).Width;
                var font = cell.Style.Font;
                if (string.IsNullOrEmpty(cellText)) combinedHeight += 0.0;
                var bitmap =new Bitmap(1,1);
                var graphics = Graphics.FromImage(bitmap);
                var pixelWidth = Convert.ToInt32(cellWidth * 6.0); //6.0 pixels per excel column width
                var drawingFont = new Font(font.Name, font.Size);
                var size = graphics.MeasureString(cellText, drawingFont, pixelWidth);
                //72 DPI and 96 points per inch.  Excel height in points with max of 409 per Excel requirements.
                combinedHeight += Math.Min(Convert.ToDouble(size.Height) * 72 / 96, 409);
                if (cellmerged) break;
                lastRowHeight = Math.Min(Convert.ToDouble(size.Height) * 72 / 96, 409);                           
            }
            calcModel.TotalCombinedHeight = combinedHeight;
            calcModel.LastRowHeight = lastRowHeight;
            columnHeights.Add(calcModel);
        }
        var row = sheet.Row(firstRowIndex + numRowsMerged - 1);
        row.CustomHeight = true;
        var maxCombo = columnHeights.Max(col => col.TotalCombinedHeight);
        var maxLast = columnHeights.Max(col => col.LastRowHeight);
        row.Height = maxCombo - maxLast;
    }
