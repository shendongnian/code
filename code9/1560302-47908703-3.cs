    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
	dt.TableName = "Table";
	dt.Columns.Add("id");
	dt.Columns.Add("value");
	dt.Rows.Add("1", "hi");
	ds.Tables.Add(dt);
		
	var dsString = JsonConvert.SerializeObject(ds);		
	var model = JsonConvert.DeserializeObject<DataTableToModel>(dsString);				
	var json = JsonConvert.SerializeObject(model.ModelProperty);
