    private void btnXML_Save_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
    	dt.TableName = "Bank";
    
    	for (int i = 0; i < dataGridView1.Columns.Count; i++)
    	{
    		//if (dataGridView1.Columns[i].Visible) // Add's only Visible columns (if you need it)
    		//{
    			string headerText = dataGridView1.Columns[i].HeaderText;
    			headerText = Regex.Replace(headerText, "[-/, ]", "_");
    
                DataColumn column = new DataColumn(headerText);
    			dt.Columns.Add(column);
    		//}
    	}
    
        foreach (DataGridViewRow DataGVRow in dataGridView1.Rows)
        {
            DataRow dataRow = dt.NewRow();
        	// Add's only the columns that you want
    		dataRow["BLZ"] = DataGVRow.Cells["BLZ"].Value;
    		dataRow["Test_1"] = DataGVRow.Cells["Test 1"].Value;
    		dataRow["Test_2"] = DataGVRow.Cells["Test-2"].Value;
    		dataRow["PIN_TAN_Test_URL"] = DataGVRow.Cells["PIN/TAN-Test URL"].Value;
    
    		dt.Rows.Add(dataRow); //dt.Columns.Add();
    	}
    	DataSet ds = new DataSet();
    	ds.Tables.Add(dt);
    
        //Finally the save part:
        XmlTextWriter xmlSave = new XmlTextWriter(XML_Save_Path_Filename, Encoding.UTF8);
        xmlSave.Formatting = Formatting.Indented;
        ds.DataSetName = "Data";
        ds.WriteXml(xmlSave);
        xmlSave.Close();
    }
