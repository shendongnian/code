        private void dg_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            if (((DataGrid)sender).CurrentCell.Column.DisplayIndex == 1 && 
                 ((Model)e.Row.Item).Name == null)
            {
                MessageBox.Show("Insert value of the first column first!");
                e.Cancel = true;
            }
        }
