    protected void mainGridView_RowDataBound(object sender, GridViewRowEventArgs e)
           {
               if (e.Row.RowType == DataControlRowType.DataRow &&
                 (e.Row.RowState == DataControlRowState.Normal ||
                  e.Row.RowState == DataControlRowState.Alternate))
               {
     
                   if (e.Row.Cells[1].FindControl("selectCheckbox") == null)
                   {
                       CheckBox selectCheckbox = new CheckBox();
                       //Give id to check box whatever you like to
                       selectCheckbox.ID = "newSelectCheckbox";
                       e.Row.Cells[1].Controls.Add(selectCheckbox);
     
                   }
               }
           }
