	DataTable table = new DataTable();
	table.Columns.Add("Re_id", typeof(int));
	table.Columns.Add("Re_nm", typeof(string));
	table.Columns.Add("parent_id", typeof(int));
	table.Rows.Add(new object[] { 151111, "region", 0 });
	table.Rows.Add(new object[] { 151112, "yemen", 151111 });
	table.Rows.Add(new object[] { 151113, "ibb", 151112 });
	table.Rows.Add(new object[] { 151117, "saudi", 151111 });
	table.Rows.Add(new object[] { 151118, "ryath", 151117 });
	AddTreeNode(null, table, 0);
	
