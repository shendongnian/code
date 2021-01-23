    DataTable dt = new DataTable();
    DataGridTableStyle tableStyle = new DataGridTableStyle();
    dt.Columns.Add(new DataColumn("ColumnName1", typeof(string)));
    dt.Columns.Add(new DataColumn("ColumnName2", typeof(string)));
    dt.Columns.Add(new DataColumn("ColumnName3", typeof(string)));
    columnStyle = new DataGridTextBoxColumn();
    columnStyle.Width = 50;
    columnStyle.MappingName = "ColumnName1";
    columnStyle.HeaderText = "ColumnName1";
    tableStyle.GridColumnStyles.Add(columnStyle);
    DataGridTextBoxColumn cs;
    cs = new DataGridTextBoxColumn();
    cs.MappingName = "ColumnName2";
    cs.Width = 160;
    cs.HeaderText = "ColumnName2";
    tableStyle.GridColumnStyles.Add(cs);
    DataGridTextBoxColumn cs2;
    cs2 = new DataGridTextBoxColumn();
    cs2.MappingName = "ColumnName3";
    cs2.Width = 100;
    cs2.HeaderText = "ColumnName2";
    tableStyle.GridColumnStyles.Add(cs2);
    dataGrid1.TableStyles.Clear(); ///dataGrid1 is the name of your DataGridView
    dataGrid1.TableStyles.Add(tableStyle);        
    SqlDataReader reader = cmd.ExecuteReader();
    DataRow dr;
    while (reader.Read())
    {
        dr = dt.NewRow();
        dr[0]=reader[0].ToString();
        dr[1]=reader[1].ToString();
        dr[2]=reader[2].ToString();
    }
    DataView dv = new DataView(dt);
    dataGrid1.DataSource =dv;
    reader.Close();
