    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (!(e.Row.Cells[10].Text.Equals("&nbsp;")))//Needed to check for this
                {
                    DateTime myDate = Convert.ToDateTime(e.Row.Cells[10].Text);
                    if (DateTime.Now < myDate)
                    {
                        e.Row.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }
