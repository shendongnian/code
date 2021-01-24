    int compareResult;
    ListViewItem listviewX, listviewY;
    // Cast the objects to be compared to ListViewItem objects
    listviewX = (ListViewItem)x;
    listviewY = (ListViewItem)y;
    // Compare the two items
    compareResult = ObjectCompare
                       .Compare
                       (listviewX.SubItems[ColumnToSort].Text,
                        listviewY.SubItems[ColumnToSort].Text);
