        private void myDataGrid_LoadingRow(object sender, System.Windows.Controls.DataGridRowEventArgs e)
        {
            if (e.Row.Item is System.Data.DataRowView)
            {
                if (((System.Data.DataRowView)e.Row.Item).IsNew)
                {
                    ((System.Data.DataRowView)e.Row.Item)[11] = false;
                    ((System.Data.DataRowView)e.Row.Item)[10] = false;
                }
            }
        }
