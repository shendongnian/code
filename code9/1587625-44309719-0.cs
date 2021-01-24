     protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                    if (ReserveStatus == "Y")
                    {
                        e.Row.BackColor = Color.Gray;
                        e.Row.ToolTip = (e.Row.DataItem as DataRowView)["TicketId"].ToString();
                    }
                   
                }
            }
