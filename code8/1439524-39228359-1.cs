        protected void gv_TT_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb1 = new LinkButton();
                lb1.ID = "Btn1";
                lb1.Text = "DeleteRow";
                lb1.CommandName = "delRow";
                //value cannot be assigned yet
                //lb1.CommandArgument = "";
                lb1.ForeColor = System.Drawing.Color.Blue;
                e.Row.Cells[1].Controls.Add(lb1);
            }
        }
