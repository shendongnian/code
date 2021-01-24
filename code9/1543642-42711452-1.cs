    protected void GridView1_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
    
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IsChecked")) == "True")
                {
                    e.Row.BackColor = System.Drawing.Color.Yellow;
                }
                else
                {
                    e.Row.ForeColor = System.Drawing.Color.Blue;
                }
    
    
            }
        }
