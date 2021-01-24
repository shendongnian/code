        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // check if it is the DataRow not the header row
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Cell[1] is the cell contain the value for the condition
                if (Convert.ToInt16(e.Row.Cells[1].Text) < 10)
                {
                    e.Row.Cells[0].BackColor = System.Drawing.Color.Yellow;
                    e.Row.Cells[1].BackColor = System.Drawing.Color.Yellow;
                }
                else if (Convert.ToInt16(e.Row.Cells[1].Text) < 30)
                {
                    e.Row.Cells[0].BackColor = System.Drawing.Color.Blue;
                    e.Row.Cells[1].BackColor = System.Drawing.Color.Blue;
                }
            }
        }
