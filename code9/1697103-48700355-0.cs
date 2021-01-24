    using Word = Microsoft.Office.Interop.Word;
    //Create a missing variable for missing value
    object missing = System.Reflection.Missing.Value;
    Word.Document ActiveDoc = Globals.ThisAddIn.Application.ActiveDocument;
    Word.Range headerRange = Globals.ThisAddIn.Application.ActiveDocument.Sections[1].Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
    ActiveDoc.Frames.Add(headerRange);
    //Place Frame at top of page
    headerRange.Frames[1].RelativeVerticalPosition = Word.WdRelativeVerticalPosition.wdRelativeVerticalPositionPage;
    headerRange.Frames[1].VerticalPosition = 0;
    headerRange.Frames[1].Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleNone;
    //Add image
    object docRange = headerRange.Frames[1].Range;
    string imagePath = @"C:\Temp\6clubs.png";
    ActiveDoc.InlineShapes.AddPicture(imagePath, ref missing, ref missing, ref docRange);
