    protected void ASPxGridView1_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            for (int i = 0; i < grid.VisibleRowCount; i++)
            {
                //Other stuff
                ASPxCheckBox checkbox = grid.FindRowCellTemplateControl(i, grid.DataColumns[0], "checkbox") as ASPxCheckBox;
                if (checkbox.Checked) //Always false
                {
                    //Do conditional stuff
                }
                //More stuff
            }
        }
