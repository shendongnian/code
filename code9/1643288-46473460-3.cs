    // Perform the binding.
    DataGrid_AuditSearch.DataSource = ds;
    DataGrid_AuditSearch.DataBind();
    
    // Create and add the custom checkbox column
	CheckBoxColumn checkBoxColumn = new CheckBoxColumn(false);
	checkBoxColumn.HeaderText = "Selected";
	DataGrid_AuditSearch.Columns.Add(checkBoxColumn);
	DataGrid_AuditSearch.DataBind();
