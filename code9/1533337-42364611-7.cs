        private void listView1_ColumnReordered(object sender, ColumnReorderedEventArgs e)
        {
            if (lvHeaderBounds != null) lvHeaderBounds.Clear();
            getHeaders(sender as ListView);
        }
        private void listView1_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            if (lvHeaderBounds != null) lvHeaderBounds.Clear();
            getHeaders(sender as ListView);
        }
