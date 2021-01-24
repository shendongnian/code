    foreach (IXLCell cell in ws.Columns("A").CellsUsed())
    {
        List<Capture> captures = new List<Capture>();
        MatchCollection matches = Regex.Matches(cell.GetValue<string>(), pattern);
        foreach (Match match in matches)
        {
            foreach (Capture capture in match.Captures)
            {
                captures.Add(capture);
            }
        }
        cell.Value = cell.GetValue<string>().Replace("<font color='gray'><s>", "").Replace("</s></font>", "");
        int contatore = 0;
        foreach (Capture capture in captures)
        {
            cell.RichText.Substring(capture.Index - contatore, capture.Length - "</s></font>".Length - "<font color='gray'><s>".Length).SetFontColor(XLColor.Gray).SetStrikethrough();
            contatore += "<font color='gray'><s></s></font>".Length;
        }
    }
