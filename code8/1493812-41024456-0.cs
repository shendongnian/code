        private void PassCustomersDataGridView_DoubleClick(object sender, EventArgs e)
        {
            System.Data.DataRowView SelectedRowView; 
            NorthwindDataSet.CustomersRow SelectedRow;
            SelectedRowView = (System.Data.DataRowView)customersBindingSource.Current; // selected row
            SelectedRow = (NorthwindDataSet.CustomersRow)SelectedRowView.Row;
           // do something like this pass data source, 
           // and then convert it back to what you the correct type at the other side
            GridData = (System.Data)customersBindingSource; 
           // Form2 OrdersForm = new Form2();
           /// set your passed in data source here
           // OrdersForm.LoadOrders(SelectedRow.CustomerID);
           // OrdersForm.Show();
        }
