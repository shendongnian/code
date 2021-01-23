    private void dataGrid_Table_InitializingNewItem(object sender, InitializingNewItemEventArgs e)
        {
            DataRowView drv = (DataRowView)e.NewItem;
            for (int i = 0; i < drv.Row.ItemArray.Count(); i++)
            {
                DataColumn col = drv.Row.Table.Columns[i];
                if (col.DataType.ToString() == "System.String")
                {
                    drv.Row[i] = "";
                }
                else if (col.DataType.ToString() == "System.Int32")
                {
                    drv.Row[i] = 0;
                }
            }
        }
