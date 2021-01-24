    //fetch the header text
    //start
    if (rowCountProducts > 0)
    {
        cellText = Server.HtmlDecode(gvProducts.HeaderRow.Cells[colIndex].Text);
    }
    else
    {
        cellText = "";
    }
    //end
