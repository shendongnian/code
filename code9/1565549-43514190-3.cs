    int compareResult = 0;//Give value because if/else
    ListViewItem listviewX, listviewY;
    // Cast the objects to be compared to ListViewItem objects
    listviewX = (ListViewItem)x;
    listviewY = (ListViewItem)y;
    // Compare the two items
    if (listviewY.SubItems[ColumnToSort].Text.Contains("%") 
     && listviewX.SubItems[ColumnToSort].Text.Contains("%"))
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
