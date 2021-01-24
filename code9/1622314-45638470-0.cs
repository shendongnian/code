    for (int i = totalWorkSheets -1 ; i >= 0; i--)
    {
        if (wb.Worksheet(i)!=null)
        {
            if (wb.Worksheet(i).Position != 1)
            {
                wb.Worksheet(i).Delete();
            }
        }
    }
