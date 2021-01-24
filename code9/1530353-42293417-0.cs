    public static void AddThatHyper()
    {
        long lr, i;
        string cellVal;
        WS = xlApp.ActiveWorkbook.ActiveSheet;
        lr = WS.Cells[WS.Rows.Count, 2].End(Excel.XlDirection.xlUp).Row;
        string prefix = "";      
    
        string topCell = "I" + 2;
        string bottomCell = "I" + lr;
        //get_Range returns object array
        Range range = ws.get_Range(topCell, bottomCell);
        
        object[,] rangeValues = new object[lr - 2, 1];
        string[,] rangeStringValues = new string[lr - 2, 1];
        rangeValues = range.Cells.Formula;
        //turn object array into string array
        //should contain strings like "=hyperlink(url, text)"
        for (int i = 0; i < rangeValues.GetLength(0); i++)
        {
            rangeStringValues[i, 0] = rangeValues[i, 0]?.ToString() ?? "";
        }
        
        //edit hyperlinks
        for (int i = 0; i < rangeStringValues.GetLength(0); i++)
        {
            prefix = "FR"
            string hyperlink = rangeStringValues[i, 0];
            MatchCollection fields =  Regex.Matches(hyperlink, @"("[A-Za-z0-9\.]*")");
            string url = fields[0]?.ToString() ?? "";
            string text = fields[1]?.ToString() ?? "";
            
            if (Regex.IsMatch(url, @"[&,\-\.]"))
                prefix = "CR";
            else if (url.Contains("'"))
            {
                prefix = "CR"
                url.Replace("'", "''");
            }
            string formattedUrl = "'" + prefix + url + "'!A1";
            rangeStringValues[i, 0]= $"=HYPERLINK(""{formattedUrl }"", "{text}")";
        }
        range.set_Value(value: values);
        range.Formula = range.Value;
    }
        
    
    
