    public DataTable TableFromMyViewModel(params MyViewModel[] items)
    {
        DataTable _result = new DataTable("MyViewModel");
        // Do this for each field
        _result.Columns.Add("Field1", typeof(String));
        _result.Columns.Add("Field2", typeof(int));
        _result.Columns.Add("Field3", typeof(String));
        
        foreach (MyViewModel _item in items)
        {
            DataRow _row = _result.NewRow();
            _row["Field1"] = _item.Field1;
            _row["Field2"] = _item.Field2;
            _row["Field3"] = _item.Field3;
        }
        return _result;
    }
