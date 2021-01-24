    List<DataGridViewColumn> orderedColumnList = new List<DataGridViewColumn>();
    DataGridViewColumn firstCol = dataGridView_Metadata.Columns.GetFirstColumn(DataGridViewElementStates.Visible);
    DataGridViewColumn nextCol = dataGridView_Metadata.Columns.GetNextColumn(firstCol, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
    while (nextCol != null)
    {
        if (nextCol.GetType() != typeof(DataGridViewUnincludedMetadataColumn))
        {
            orderedColumnList.Add(nextCol);                        
        }
        nextCol = dataGridView_Metadata.Columns.GetNextColumn(nextCol, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
    }
