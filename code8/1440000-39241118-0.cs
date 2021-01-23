    if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DateTime curDate = DateTime.Now
                if (Convert.ToDateTime(e.Row.Cells[2].Text) < curDate)
                {
                   //color code
                }
        }
