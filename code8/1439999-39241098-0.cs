    try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DateTime dtRow = DateTime.ParseExact(e.Row.Cells[2].Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                DateTime curDate = DateTime.Now;
                int result = DateTime.Compare(dtRow, curDate);
                if ( result < 0 )
                {
                   //color code
                }
        }
