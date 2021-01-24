    if (Datagrid1.SelectedIndex != -1 && Datagrid1.SelectedIndex != 0)
    {
      int index = Datagrid_PMP.SelectedIndex;
      DataRow downrow = ((DataRowView)(Datagrid1.SelectedItem)).Row;
      DataRow temprow = sourceTable.NewRow();
      temprow.ItemArray = downrow.ItemArray;
      sourceTable.Rows.Remove(downrow);
      Datagrid1.SelectedIndex = index - 1;
      DataRow uprow = ((DataRowView)(Datagrid1.SelectedItem)).Row;
      int i = dset.Tables[2].Rows.IndexOf(uprow);
      sourceTable.Rows.InsertAt(temprow, i);
      Datagrid1.SelectedIndex = index - 1;
    }
