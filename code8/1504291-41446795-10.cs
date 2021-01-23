    for(int i = 0; i < grid.VisibleRowCount; i++)
    {
        ASPxCheckBox checkbox = grid.FindRowCellTemplateControl(i, grid.Columns[0], "checkbox") as ASPxCheckBox;
        ((IPostBackDataHandler)checkbox).LoadPostData(checkbox.UniqueID, Request.Form);
        if(checkbox.Checked)
        {
            //Do conditional stuff
        }
    }
