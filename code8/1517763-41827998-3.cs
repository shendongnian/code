    private void load_gridView()
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("page");
                dt.Columns.Add("navigation");
    
                DataRow dr = dt.NewRow();
                dr["page"] = "family tours";
                dr["navigation"] = "family_tours.aspx";
                dt.Rows.Add(dr);
    
                DataRow dr2 = dt.NewRow();
                dr2["page"] = "religious tour";
                dr2["navigation"] = "religious_tour.aspx";
                dt.Rows.Add(dr2);
    
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
    
     protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                HiddenField hdn_navigation = (HiddenField)row.FindControl("hdn_navigation");
                if (e.CommandName.ToString() == "navigation")
                {
                    Response.Redirect(hdn_navigation.Value);
                }
            }
