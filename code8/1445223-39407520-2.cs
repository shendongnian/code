    var sCol2 = string.Empty;
    foreach(var item in ddlcol2.Items)
    {
        if (item.Selected)
            sCol2 += "'" + item.Value + "',"
    }
    // remove the last ,
    if (sCol2.Length > 0)
        sCol2 = sCol2.Substring(0, sCol2.Length - 1);
    string qry = "select * from Collections where col1 = '" +
                 ddlcol1.SelectedValue.ToString() +
                 "' and col2 in (" +
                 sCol2 + ")";
