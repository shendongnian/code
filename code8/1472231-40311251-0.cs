    public void FSetDataBinding(object BindingObject, string FieldName)
    {
        Binding ControlBinding = new Binding("Checked", BindingObject, FieldName, true) { DataSourceNullValue = false };
        ControlBinding.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
        DataBindings.Add(ControlBinding);
    }
