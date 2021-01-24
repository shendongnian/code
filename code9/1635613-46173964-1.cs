        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // find your textbox control in gridview
                TextBox tb = (TextBox)e.Row.FindControl("txtboxtobehidden");
        
                if(tb.Text == "")
                    tb.Text = "NA";
            }
        }
