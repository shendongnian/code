    rah.rahTermDate = new List<RawACAHireTermDates>();
    
    for (int i = 0; i < 5; i++)
    {                  
        RawACAHireTermDates rahd = new RawACAHireTermDates();
        rahd.RawHireDate = Convert.ToDateTime(GetCellValue(GetCell(sheetData, Cells[i, k], j), workbookPart, false, true));
        rahd.RawTermDate = Convert.ToDateTime(GetCellValue(GetCell(sheetData, Cells[i, (k + 1)], j), workbookPart, false, true));
        rah.rahTermDate.Add(rahd);
        // rah.rahTermDate = new List<RawACAHireTermDates> { rahd }; <-- this line was the problem
    }
