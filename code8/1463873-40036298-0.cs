    protected void gridId_RowDataBound(object sender, GridViewRowEventArgs e)
    {
         if (e.Row.RowType == DataControlRowType.DataRow)
         {
              DataSourceClass varData = (DataSourceClass)e.Row.DataItem;
              // check if your data have flag to show the link
              if(varData.show)
                ((LinkButton)e.Row.FindControl("linkbuttonId")).Visible = true;
              else
                ((LinkButton)e.Row.FindControl("linkbuttonId")).Visible = false;
         }
    }
