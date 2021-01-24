    // Need to create a DataView from your original DataSet
    // and set the view to the default view from your DataSet.
    DataView view = new DataView();
    view = myDataSet.Tables[0].DefaultView;
    // Next, create a filter on that view
    view.RowFilter = "State = 'CA'";
    // Now create a DataTable from the view
    // and set the DataSource of the DataGridView to that DataTable.
    DataTable dt = view.ToTable("tablename");
    dgrdToDisplay.DataSource = dt;
