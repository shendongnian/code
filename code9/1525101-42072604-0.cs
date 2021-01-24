    public DataTable TableFromMyViewModel(MyViewModel item)
    {
        DataTable _result = new DataTable("MyViewModel");
        // Do this for each field
        _result.Columns.Add("Field1", typeof(String));
        _result.Columns.Add("Field2", typeof(int));
        _result.Columns.Add("Field3", typeof(String));
        return _result;
    }
