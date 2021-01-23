    protected void btnDeleteOK_Click(object sender, EventArgs e)
    {
        dtItems = new DataTable();
        dtItems.Columns.Add("RowId");
        dtItems.Columns.Add("ItemId");
        dtItems.Columns.Add("Percentage", typeof(decimal));
        dtItems.Columns.Add("LabDipId");
        dtItems.Columns.Add("RecipeId");
    
        foreach (GridViewRow gr in gdDyeNames.Rows)
        {
            TextBox txtPercentage = (TextBox)gr.FindControl("txtPercentage");
            DropDownList ddlDyeingType = ((DropDownList)gr.FindControl("ddlDyeingType"));
    
            DataRow dr = dtItems.NewRow();
    
            dr["RecipeId"] = SelectedReciptId;
            dr["ItemId"] = int.Parse(ddlDyeingType.SelectedValue.ToString());
            dr["Percentage"] = decimal.Parse(txtPercentage.Text).ToString();
            dtItems.Rows.Add(dr);
        }
    
    	
    		ImageButton btnDetails = (ImageButton)sender; //Change Image button to your Button used
    		GridViewRow row = (GridViewRow)btnDetails.NamingContainer;
    		int rowIndex = row.RowIndex; 
    		DataRow dr = dtItems.Rows[rowIndex];
    		dtItems.Rows.Remove(dr);
    		dtItems.AcceptChanges();
    
        gdDyeNames.DataSource = dtItems;
        gdDyeNames.DataBind();
    
        lblEror.Text = "";
        lblMsg.Text = "";
        mpdelete.Hide();
    }
