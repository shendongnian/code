    protected void GVAllProjects_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check if the row is a datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //check if the edit state > 0
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                //do stuff with the row that is being edited
            }
        }
    }
