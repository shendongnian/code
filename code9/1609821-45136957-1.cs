    if (extension == ".xls")
    {
        excelConnectionString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;\"", strCSVFilePath);
    }
    else
    {
         excelConnectionString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 xml;HDR=YES;IMEX=1;\"", strCSVFilePath);
    }
