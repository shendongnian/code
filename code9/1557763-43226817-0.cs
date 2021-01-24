    int myDefaultWidth = 100;
    myDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
    foreach ( DataGridViewColumn column in myDataGridView.Columns )
    {
        if ( column.Width < myDefaultWidth)
        {
            column.Width = myDefaultWidth;
        }
    }
