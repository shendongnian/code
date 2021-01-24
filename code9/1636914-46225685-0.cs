        Workbook workbook = new Workbook("e:\\test2\\Book1.xlsx");
        Worksheet worksheet = workbook.Worksheets[0];
        ImageOrPrintOptions printoption = new ImageOrPrintOptions();
        printoption.PrintingPage = PrintingPageType.Default;
        SheetRender sr = new SheetRender(worksheet, printoption);
        int pageCount = sr.PageCount;
        MessageBox.Show(pageCount.ToString());
        CellArea[] area = worksheet.GetPrintingPageBreaks(printoption);
        MessageBox.Show(area.Length.ToString());
        for (int i = 0; i < area.Length; i++)
        {
            //Get the first page rows. 
            int strow = area[i].StartRow;
            int stcol = area[i].StartColumn;
            MessageBox.Show("Page " + (i + 1).ToString() + " : " + CellsHelper.CellIndexToName(strow, stcol));
        }
