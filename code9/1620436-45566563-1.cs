    protected void bt_save_Click(object sender, EventArgs e)
    {
        // a GridViewRow has cells ...
        foreach (GridViewRow row in gv_result_tw.Rows)
        {
            // ... the cells are of type DataControlFieldCell
            foreach (DataControlFieldCell col in row.Cells)
            {
                // ... but we get some bonus fields as well 
                if (col.Controls.Count > 0)
                {
                    // .. if we skip those 
                    // ... we get a cell that has its ID set to the value
                    // that was used to generate the ID of the hiddenfield
                    var columnNameField = row.FindControl(col.ID + "_hidden_time") as HiddenField;
                   // columnNameField will not be null now ...
                }
            }
        }
    }
