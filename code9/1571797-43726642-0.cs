    protected void ddlSectionItem_SelectedIndexChanged(object sender, EventArgs e)
            {
    
                DropDownList ddl = sender as DropDownList;
    
    
                objInvoiceUser.P_Section_ID = int.Parse(ddl.SelectedItem.Value);
              
                DataSet ds = objInvoiceUser.GetAllBySection();
    
                if (ds.Tables[0].Rows.Count > 0)
                {
    
                   
                    ***Label lblCatName = (Label)grdBOQ.FooterRow.FindControl("lblCatName");***
                    lblCatName.Text = ds.Tables[0].Rows[0]["SECTION_CAT_NAME"].ToString();
    
              
                }
    
            }
