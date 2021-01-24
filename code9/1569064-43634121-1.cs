    protected void gridmeta_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gridmeta.EditIndex = e.NewEditIndex;
        fillGrid();
    }
    
    
    protected void gridmeta_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gridmeta.EditIndex = -1;
        fillGrid();
    }
    
    
    protected void gridmeta_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int index;
        index = e.RowIndex;
        int metaid = Convert.ToInt32(gridmeta.DataKeys[index].Value.ToString());
        string content = ((TextBox)gridmeta.Rows[index].FindControl("txtcontent")).Text;
        //Your Code to update an entry based on id in this case metaid
    }
