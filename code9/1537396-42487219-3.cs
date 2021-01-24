    private void advancedListView1_ColumnClick(object sender, ColumnClickEventArgs e)
    {
        advancedListView1.Sorting = advancedListView1.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
        advancedListView1.ListViewItemSorter = new ListViewSorter(advancedListView1.Sorting, e.Column, advancedListView1);
    }
