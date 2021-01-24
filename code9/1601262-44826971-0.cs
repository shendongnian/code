    class UI
    {
        public void PopulateDatagridview()
        {
            var items = new List<Item> // - create/load items
            datagridview1.DataSource = items;
        }
        private void datagridview1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                var gridView = (DataGridView)sender;
                var item = (Item)gridView.CurrentRow.DataBoundItem;
                var nameForCopy = item.Name;  
                // use nameForCopy ...             
            }
        } 
    }
