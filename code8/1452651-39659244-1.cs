    private void GetGenericTableContent<T>(ref StringBuilder outputTableContent, T item) 
        where T : IMyInterface
    {
        outputTableContent.Append("<td>" + item.SpreadsheetLineNumbers + "</td>");
    }
