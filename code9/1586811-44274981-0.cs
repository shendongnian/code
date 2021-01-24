    private void dataGridView1_SortCompare(object sender,
                DataGridViewSortCompareEventArgs e)
    {
        // Sort the size column
        if (e.Column.Name == "Size")
        {
            e.SortResult = new SizeComparer().Compare(
                e.CellValue1.ToString(), e.CellValue2.ToString());
            e.Handled = true;
        }
    }
