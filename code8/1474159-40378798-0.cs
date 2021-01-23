    //Make column F a date column. Alter to a specific range if the whole column shouldn't be of date type.
    Range rg = ws.Range("F:F");
    rg.EntireColumn.NumberFormat = "MM/DD/YYYY";
    var lblpkgdate = (Label).gvvessel.Rows[j].FindControl("lblpackagedate");
    //Convert lblpkgdate text to DateTime object assuming format of dd/MM/yyyy to ensure it is actually a date.
    DateTime pkgDate = DateTime.ParseExact(lblpkgdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
    for(int i = 1, i < YourMaxRowValue, i++)
    {
        ws.Cell("F" + i).Value = pkgDate;
    }
        
