    protected void btn_Submit_Click(object sender, EventArgs e)
    {
    	DataTable combinedDataTable;
    	foreach (GridViewRow row in gvImage.Rows)
    	{
    		if (row.RowType == DataControlRowType.DataRow)
    		{
    			bool isChecked = row.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked;
    			if (isChecked)
    			{
    				DataTable data = //Data from database for this checkbox
    				if(combinedDataTable != null)
    					combinedDataTable.Merge(data);
    				else
    					combinedDataTable = data;
    			}
    		}
    	}
    	GridView1.DataSource = combinedDataTable;
    	GridView1.DataBind();
    }
