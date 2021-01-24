    //Copies cell C3
    Range cellToCopy = (Range)activeWorksheet.Cells[3, 3];
    cellToCopy.Copy();
    
    //Paste format only to the cell C5
    Range cellToPaste = (Range)activeWorksheet.Cells[5, 3];
    cellToPaste.PasteSpecial(XlPasteType.xlPasteFormats);
