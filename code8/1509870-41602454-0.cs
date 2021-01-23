    string sql = "select * from foo";
    string source = "your connection string here";
    Excel.ListObject lo = sheet.ListObjects.AddEx(Excel.XlListObjectSourceType.xlSrcQuery,
        source, true, Excel.XlYesNoGuess.xlGuess, range);
    try
    {
        lo.QueryTable.CommandText = sql;
        lo.Refresh();
    }
    catch (Exception ex)
    {
        ErrorMessage = ex.ToString();
    }
