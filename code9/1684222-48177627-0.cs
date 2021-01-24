       protected void grdEstimateDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {   
            String[] arr = new String[6];
            arr[0] = "Malarkey";
              if (e.Row.RowType == DataControlRowType.DataRow)
              {
               // Following line may not be necessary but could prove to be usefull 
               //System.Data.DataRowView dr = (System.Data.DataRowView)e.Row.DataItem;
               Label lblctrl = (Label)e.Item.FindControl("ProductDetail");
               ImageButton btnDuplicateRow1 = (ImageButton)e.Item.FindControl("btnDuplicateRow");
                if (arr.Contains(lblctrl.Text))
                {
                   btnDuplicateRow1.Visible = false;
                }
           }
        }
   
