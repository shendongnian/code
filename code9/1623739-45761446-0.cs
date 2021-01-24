    // If you are using an existing table layout panel, either clear the controls, rows and columns beforehand,
    // or keep track of them manually and adjust accordingly.
    tableLayoutPanel.Controls.Clear();
    tableLayoutPanel.RowStyles.Clear();
    tableLayoutPanel.ColumnStyles.Clear();
    IList<DataGridView> dataGridViews = ... /* wherever you get your data grid views from */
    for (int i = 0; i < dataGridViews.Count; ++i)
    {
        // The arguments to ColumnStyle control the size of the column.
        // If you want to arrange them vertically instead of horizontally, use RowStyles instead.
        // If you want a combination, you have to figure out the logic yourself.
        // In case of SizeType.Percent, "width" defines a relative weight, not necessarily percent.
        // If all widths are equal (no matter the value), all columns will be equally wide.
        tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, width: 1));
        dataGridViews[i].Dock = DockStyle.Fill;
        // This adds the data grid view into that specific cell.
        tableLayoutPanel.Controls.Add(dataGridViews[i], column: i, row: 0);
    }
