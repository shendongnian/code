    private void Initialize()
    {
        RegisterBindingSourceEvents();
        dataGridView1.DataSource = bindingSource1;
        dataGridView2.DataSource = bindingSource2;
        bindingSource1.DataSource = myDataSource;
    }
    private void RegisterBindingSourceEvents()
    {
        bindingSource1.DataSourceChanged += BindingSource1_DataSourceChanged;
        bindingSource1.CurrentChanged += BindingSource1_CurrentChanged;
    }
    private void BindingSource1_CurrentChanged(object sender, EventArgs e)
    {
        DataRowView row = bindingSource1.Current as DataRowView;
        if (row != null)
            bindingSource2.DataSource = myDataSource2BasedOnRow;
    }
    private void BindingSource1_DataSourceChanged(object sender, EventArgs e)
    {
        DataRowView row = bindingSource1.Current as DataRowView;
        if (row != null)
            bindingSource2.DataSource = myDataSource2BasedOnRow;
    }
