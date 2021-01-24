    rdadmin.AllowAddingRecords = false;
    
    protected void Grid1_RowDataBound(object sender, GridRowEventArgs e)
    {
        GridDataControlFieldCell cell = e.Row.Cells[10] as GridDataControlFieldCell;
        Control linksContainer = cell.Controls[0].Controls[0];
    
        bool disableEdit = false;
        bool disableDelete = false;
        disableEdit = true;
        disableDelete = true;
        linksContainer.Controls[0].Enabled = !disableEdit;
        linksContainer.Controls[2].Enabled = !disableDelete;
        linksContainer.Controls[1].Enabled = !disableEdit && !disableDelete;
    }
