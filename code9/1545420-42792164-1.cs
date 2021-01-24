    DataTable dt = new DataTable();
    dt.Columns.Add("ContainerId", typeof(Int32));
    dt.Columns.Add("ContainerNumber", typeof(String));
    dt.Columns.Add("Title", typeof(String));
    dt.Columns.Add("Date", typeof(DateTime));
    foreach(var fld in fields)
    {
    	dt.Columns.Add(fld, typeof(String));
    }
