    string[] htmlTables = ParseHtmlSplitTables(htmlString);
    foreach (string html in htmlTables)
    {
        List<List<KeyValuePair<string, string>>> parseResult = ParseHtmlToDataTable(html);
        DataTable dataTable = ToDataTable(parseResult);
    }
