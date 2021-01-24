    protected void Button1_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("Column1", typeof(string)));
        dt.Columns.Add(new DataColumn("Column2", typeof(string)));
        dt.Columns.Add(new DataColumn("Column3", typeof(string)));
        dt.Columns.Add(new DataColumn("Column4", typeof(string)));
        dt.Columns.Add(new DataColumn("Column5", typeof(string)));
        DataRow dr = null;
        foreach (GridViewRow row in GridViewclass.Rows)
        {
            dr = dt.NewRow();
            dr["RowNumber"] = row.Cells[1].Text;
            dr["Column1"] = ((TextBox)row.FindControl("TextBox1")).Text;
            dr["Column2"] = ((TextBox)row.FindControl("TextBox2")).Text;
            dr["Column3"] = ((TextBox)row.FindControl("TextBox3")).Text;
            dr["Column4"] = ((TextBox)row.FindControl("TextBox4")).Text;
            dr["Column5"] = ((TextBox)row.FindControl("TextBox5")).Text;
            dt.Rows.Add(dr);
        }
        //this will insert data of dt into database
        BulkDataInsert(dt, "connectionString");
    }
    void BulkDataInsert(DataTable dataTable, string connectionString)
	{
		try
		{
			SqlBulkCopy bulkCopy = new SqlBulkCopy(connectionString, SqlBulkCopyOptions.TableLock)
			{
				DestinationTableName = txtTableName.Text,
				BatchSize = 100000,
				BulkCopyTimeout = 360
			};
			bulkCopy.WriteToServer(dataTable);
	
			//Data Inserted Succesfull
		}
		catch (Exception ex)
		{
			//ex.Message)
		}
	}
