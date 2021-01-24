    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        {
            GridViewRow headerrow = GridView1.HeaderRow;
            DropDownList ddlId = (DropDownList)headerrow.Cells[0].Controls[1].FindControl("ddlId ");
            string headerid = ddlId.SelectedValue; 
        }
    }
