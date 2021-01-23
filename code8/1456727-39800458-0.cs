    dt = new DataTable();
    dt.Columns.Add("C1", typeof(int)).AllowDBNull = true;
    var bs = new BindingSource();
    bs.DataSource = dt;
    checkBox1.ThreeState = true;
    checkBox1.DataBindings.Add("CheckState", bs, "C1", true,
        DataSourceUpdateMode.OnPropertyChanged, CheckState.Indeterminate);
    this.bindingNavigator1.BindingSource = bs;
