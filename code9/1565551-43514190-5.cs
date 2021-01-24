    int compareResult = 0;//Give value because if/else
    ListViewItem listviewX, listviewY;
    // Cast the objects to be compared to ListViewItem objects
    listviewX = (ListViewItem)x;
    listviewY = (ListViewItem)y;
    
    Regex percentageExpr = new Regex(@"^([1-9]?[0-9]|100)( %|%)");
    // Compare the two items
    if (percentageExpr.IsMatch(listviewY.SubItems[ColumnToSort].Tex‌​t) 
     && percentageExpr.IsMatch(listviewX.SubItems[ColumnToSort].Text‌​))
    {
        int textY = Convert.ToInt32( listviewY.SubItems[ColumnToSort]
                                     .Text.Replace( "%", String.Empty ) );
        int textX = Convert.ToInt32( listviewX.SubItems[ColumnToSort]
                                     .Text.Replace( "%", String.Empty ) );
        compareResult =
        ( textX > textY )
            ? 1
            : textX == textY
                    ? 0 : -1;
    }
    else
    {
        compareResult = ObjectCompare
                       .Compare
                       (listviewX.SubItems[ColumnToSort].Text
                       , listviewY.SubItems[ColumnToSort].Text);
    }
