using (ExcelRange rng = xlsheetSummary.Cells[1, 1])
{
    var namedStyle = xlsheetSummary.Workbook.Styles.NamedStyles.FirstOrDefault(o=> o.Name == "HyperLink");
                                
    namedStyle.Style.Font.UnderLine = true;
    rng.StyleName = namedStyle.Name;
    rng.Value = ws.Name;
    Uri link = new Uri($"{workbookPath}#'{sheetName}'!B5", UriKind.Relative);
    namedStyle.Style.Font.Color.SetColor(Color.Blue);                                 
    rng.Hyperlink = link;
}
