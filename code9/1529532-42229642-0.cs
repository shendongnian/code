    GridViewDataColumn IsCalibratedUSedColumn = new GridViewDataColumn()
    {
        UniqueName = "IsCalibratedUSedColumn",
        Header = "Use calibrated",
        DataMemberBinding = new Binding("IsCalibratedUSed"),
        IsFilterable = false,
    };
    Binding enablityBinding = new Binding("IsNotCalibratedYet");
    enablityBinding.Mode = BindingMode.OneWay;
    enablityBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
    IsCalibratedUSedColumn.IsReadOnlyBinding = enablityBinding;
    this.Columns.Add(IsCalibratedUSedColumn);
