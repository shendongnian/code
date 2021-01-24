    int rowNum = 1;  // Row numbering starts at 1
    for (int i = 0; i < myData.Count; i++) {
        var row = worksheet.Row(rowNum);
        if (isEndOfGroup) {
            row.InsertRowsBelow(1);
            rowNum++;
            var rowBelow = row.RowBelow();
            // Do stuff with the added row, like adding a subtotal
        }
        rowNum++;
    }
