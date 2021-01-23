    class MyListView : System.Windows.Forms.ListView
    {
        public MyListView()
        {
            this.Sorting = System.Windows.Forms.SortOrder.None;
            this.ListViewItemSorter = null;
        }
    }
